using System.Drawing;
using System.Collections.Generic;
using System.Xml;
using System.Linq;

class SVGDrawer : Drawer
{
	XmlWriter writer;

	Dictionary<Point, List<Point>> lines;
	Point start;
	bool started;

	public SVGDrawer(XmlWriter writer) : base() 
	{
		started = false;
		this.writer = writer;
	}

	public void StartObject()
	{
		started = true;
		lines = new Dictionary<Point, List<Point>>();
		start = Point.Empty;
	}

	public void StopObject()
	{
		if (!started)
			return;

		started = false;

		Point point = start;

		//write lines
		while (lines.Count > 0)
		{
			WriteSVG(MakePolyLine(point));		//make line, print line

			if (lines.Count > 0)
				point = lines.Keys.First();		//next polyline
		}
	}

	private string MakePolyLine(Point start)
	{
		Point point = start;
		string line = "";

		//go over points
		while (point != Point.Empty)
		{
			line += point.X + "," + point.Y + " ";

			if (lines.ContainsKey(point))
			{
				Point next = lines[point][0];
				RemoveLine(point, next);
				RemoveLine(next, point);
				point = next;
			}
			else
				point = Point.Empty;
		}

		return line;
	}

	private void WriteSVG(string line)
	{
		writer.WriteStartElement("polyline");
		writer.WriteAttributeString("points", line);
		writer.WriteAttributeString("style", "fill:none;stroke:black;stroke-width:1");
		writer.WriteEndElement();
	}

	private void RemoveLine(Point p1, Point p2)
	{
		if (lines.ContainsKey(p1))
		{
			lines[p1].Remove(p2);
			if (lines[p1].Count == 0)
				lines.Remove(p1);
		}
	}

	private void AddLine(Point p1, Point p2)
	{
		if (!lines.ContainsKey(p1))
			lines.Add(p1, new List<Point>());
		lines[p1].Add(p2);
	}

	public override void DrawLine(Color color, int x1, int y1, int x2, int y2)
	{
		if (!started)
		{
			WriteSVG(x1 + "," + y1 + " " + x2 + "," + y2);
			return;
		}

		Point p1 = new Point(x1, y1);
		Point p2 = new Point(x2, y2);

		if (start == Point.Empty)
			start = p1;             //set starting point

		//add lines
		AddLine(p1, p2);
		AddLine(p2, p1);
	}

	public override void DrawCircle(Color color, int x, int y, int diameter)
	{
		writer.WriteStartElement("circle");
		writer.WriteAttributeString("cx", (x + diameter / 2).ToString());
		writer.WriteAttributeString("cy", (y + diameter / 2).ToString());
		writer.WriteAttributeString("r", (diameter / 2).ToString());
		writer.WriteAttributeString("stroke-width", "1");
		writer.WriteAttributeString("fill", "none");
		writer.WriteAttributeString("stroke", "black");
		writer.WriteEndElement();
	}
}

