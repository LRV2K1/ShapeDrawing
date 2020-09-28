using System;
using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;


class SVGDrawer : Drawer
{
	public SVGDrawer() : base()
	{

	}


	public override void DrawLine(Color color, int x1, int y1, int x2, int y2)
	{
	}

	public override void DrawCircle(Color color, int x, int y, int radius)
	{
	}

	// What to do when the user wants to export a SVG file
	private void exportHandler(object sender, EventArgs e)
	{
		Stream stream;
		SaveFileDialog saveFileDialog = new SaveFileDialog();

		saveFileDialog.Filter = "SVG files|*.svg";
		saveFileDialog.RestoreDirectory = true;

		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			if ((stream = saveFileDialog.OpenFile()) != null)
			{
				// Insert code here that generates the string of SVG
				//   commands to draw the shapes
				using (StreamWriter writer = new StreamWriter(stream))
				{
					// Write strings to the file here using:
					//   writer.WriteLine("Hello World!");
				}
			}
		}
	}

}

