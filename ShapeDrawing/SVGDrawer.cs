using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Xml;

class SVGDrawer : Drawer
{
	XmlWriter writer;

	public SVGDrawer(XmlWriter writer) : base() 
	{
		this.writer = writer;
	}

	public void StartObject()
	{
	}

	public void StopObject()
	{
	}

	public override void DrawLine(Color color, int x1, int y1, int x2, int y2)
	{
		writer.WriteStartElement("polyline");
		writer.WriteAttributeString("points", x1 + "," + y1 + " " + x2 + "," + y2);
		writer.WriteAttributeString("style", "fill:none;stroke:black;stroke-width:1");
		writer.WriteEndElement();
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

