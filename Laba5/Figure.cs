namespace Laba5;

internal class Figure
{
    protected int centerX;
    protected int centerY;
    protected Color color;
    protected Graphics g = Form.ActiveForm!.CreateGraphics();
    public Figure(int centerX, int centerY, Color color)
    {
        this.centerX = centerX;
        this.centerY = centerY;
        this.color = color;
    }
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
