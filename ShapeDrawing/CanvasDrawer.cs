using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

class CanvasDrawer : Drawer
{
    Graphics graphics;
    public CanvasDrawer(Graphics graphics) : base() 
    {
        this.graphics = graphics;
    }

    public override void DrawLine(Color color, int x1, int y1, int x2, int y2)
    {
        Pen pen = new Pen(color);
        graphics.DrawLine(pen, x1, y1, x2, y2);
    }

    public override void DrawCircle(Color color, int x, int y, int diameter)
    {
        Pen pen = new Pen(color);
        graphics.DrawEllipse(pen, x, y, diameter, diameter);
    }
}