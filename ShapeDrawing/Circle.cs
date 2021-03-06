﻿using System.Drawing;

class Circle : Shape
{

    private int x;
	private int y;
	private int size;

    public Circle(int x, int y, int size)
    {
		this.x = x;
		this.y = y;
		this.size = size;
    }

    public override void Draw(Drawer drawer)
    {
        Color color = Color.Black;
        drawer.DrawCircle(color, this.x, this.y, this.size);
    }
}
