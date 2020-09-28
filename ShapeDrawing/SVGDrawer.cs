using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;


class SVGDrawer : Drawer
{
	StreamWriter writer;
	public SVGDrawer(StreamWriter writer) : base() 
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
		writer.WriteLine("    <polyline points=\"" + x1 + ", " + y1 + " " + x2 + ", " + y2 + "\" style=\"fill:none;stroke:black;stroke-width:1\" />");
	}

	public override void DrawCircle(Color color, int x, int y, int radius)
	{
		writer.WriteLine("    <circle cx=\"" + x + "\" cy=\"" + y + "\" r=\"" + (radius/2) + "\" stroke-width=\"1\" fill=\"none\" stroke=\"black\" />");
	}
}

