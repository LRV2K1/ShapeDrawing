using System.Drawing;

class Rectangle : Shape
{

    private int x;
	private int y;
	private int width;
	private int height;

    public Rectangle(int x, int y, int width, int height)
    {
		this.x = x;
		this.y = y;
		this.width = width;
		this.height = height;
    }
    
	public override void Draw(Drawer drawer)
    {
		Color color = Color.Black;
		drawer.DrawLine(color, x,y,x + width,y);
		drawer.DrawLine(color, x+width,y,x+width,y+height);
		drawer.DrawLine(color, x+width,y+height,x,y+height);
		drawer.DrawLine(color, x,y+height,x,y);
    }
}