namespace Laba5;

internal class Square : Figure
{
    private int sideLength;
    public Square(int centerX, int centerY, Color color, int sideLength) : base(centerX, centerY, color)
    {
        this.SideLength = sideLength;
    }
    public int SideLength { get => sideLength; set => sideLength = value; }
    protected override Point[] GetPoints()
    {
        return [
            new Point(centerX - sideLength, centerY - sideLength),
            new Point(centerX + sideLength, centerY - sideLength),
            new Point(centerX + sideLength, centerY + sideLength),
            new Point(centerX - sideLength, centerY + sideLength),
        ];
    }

    public override void DrawFigure()
    {
        g.FillPolygon(new SolidBrush(color), GetPoints());
    }
    public override void HideFigure()
    {
        g.FillPolygon(new SolidBrush(Form1.DefaultBackColor), GetPoints());
    }
}