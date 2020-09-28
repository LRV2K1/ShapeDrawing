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

	public override void DrawLine(Color color, int x1, int y1, int x2, int y2)
	{
	}

	public override void DrawCircle(Color color, int x, int y, int radius)
	{
	}
}

