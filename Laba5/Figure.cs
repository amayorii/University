﻿namespace Laba5;

internal class Figure
{
    protected int centerX;
    protected int centerY;
    protected Color color;
    protected Graphics g = new Form1().CreateGraphics();
    public Figure(int centerX, int centerY, Color color)
    {
        this.centerX = centerX;
        this.centerY = centerY;
        this.color = color;
    }
    protected virtual Point[] GetPoints() => [];
    public virtual void DrawFigure() { }
    public virtual void HideFigure() { }
    public void MoveRightOn(int pixels)
    {
        Task.Run(() =>
        {
            for (int i = 0; i < pixels; i++, centerX++)
            {
                DrawFigure();
                Thread.Sleep(50);
                HideFigure();
            }
        });
    }
}
