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
    
	public override void Draw(Drawer Canvas)
    {
		Pen pen = new Pen(Color.Black);
		Canvas.DrawLine(Color.Black,x,y,x + width,y);
		Canvas.DrawLine(Color.Black,x+width,y,x+width,y+height);
		Canvas.DrawLine(Color.Black,x+width,y+height,x,y+height);
		Canvas.DrawLine(Color.Black,x,y+height,x,y);
    }
}

