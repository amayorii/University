
namespace Laba5;

internal class Ellipse : Figure
{
    private int radius;
    public Ellipse(int centerX, int centerY, Color color, int radius) : base(centerX, centerY, color)
    {
        Radius = radius;
    }
    public override void DrawFigure()
    {
        g.FillEllipse(new SolidBrush(color), new Rectangle(centerX, centerY, radius, radius));
    }
    public override void HideFigure()
    {
        g.FillEllipse(new SolidBrush(Form1.DefaultBackColor), new Rectangle(centerX, centerY, radius, radius));
    }
    public int Radius { get => radius; set => radius = value; }
}
