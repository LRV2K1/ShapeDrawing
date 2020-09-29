using System.Drawing;

public abstract class Drawer
{
    public Drawer() { }

    public abstract void DrawLine(Color color, int x1, int y1, int x2, int y2);

    public abstract void DrawCircle(Color color, int x, int y, int diameter);
}