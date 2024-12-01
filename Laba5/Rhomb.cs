using System.Drawing.Drawing2D;

namespace Laba5;

internal class Rhomb : Figure
{
    private int horDiagLen;
    private int vertDiagLen;

    public int HorDiagLen { get => horDiagLen; set => horDiagLen = value; }
    public int VertDiagLen { get => vertDiagLen; set => vertDiagLen = value; }

    public Rhomb(int centerX, int centerY, Color color, int horDiagLen, int vertDiagLen)
        : base(centerX, centerY, color)
    {
        this.HorDiagLen = horDiagLen;
        this.VertDiagLen = vertDiagLen;
    }
    private GraphicsPath GetPath()
    {
        GraphicsPath myPath = new GraphicsPath();
        myPath.AddLines(new[] {
                new Point(centerX, centerY + (vertDiagLen / 2)),
                new Point(centerX + (horDiagLen / 2), centerY),
                new Point(centerX + horDiagLen, centerY + (vertDiagLen / 2)),
                new Point(centerX + (horDiagLen / 2), centerY + vertDiagLen),
                new Point(centerX, centerY + (vertDiagLen / 2))
        });
        return myPath;
    }
    public override void DrawFigure()
    {
        g.FillPath(new SolidBrush(color), GetPath());
    }
    public override void HideFigure()
    {
        g.FillPath(new SolidBrush(Form1.DefaultBackColor), GetPath());
    }
}
