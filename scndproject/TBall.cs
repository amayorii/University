namespace scndproject;

public class TBall : TDisk
{
    protected double z;

    public TBall(double x, double y, double z, double r) : base(x, y, r)
    {
        this.z = z;
    }

    public TBall() : base()
    {
        Input();
    }

    public TBall(TBall obj)
    {
        X = obj.X;
        Y = obj.Y;
        Z = obj.Z;
        R = obj.R;
    }

    public double Z
    {
        get { return z; }
        set { z = value; }
    }

    void Input()
    {
        System.Console.Write("Z: "); Z = Convert.ToDouble(Console.ReadLine());
    }
    public new void Output()
    {
        System.Console.WriteLine("\nX: {0}, Y: {1}, Z: {2}\nRadius {3} cm\nArea: {4} cm²\nVolume: {5} cm³", X, Y, Z, R, Area(), Volume());
    }
    public override string ToString()
    {
        return string.Format($"X: {X}, Y: {Y}, Z: {Z}\nRadius: {R} cm\nArea: {Area()} cm²\nVolume: {Volume()} cm³");
    }

    public new double Area()
    {
        return base.Area() * 4;
    }
    public double Volume()
    {
        return 4.0 / 3.0 * base.Area() * R;
    }
    public bool DoesPointBelongToSphere(double x, double y, double z)
    {
        return R > Math.Sqrt(Math.Pow(x - X, 2) + Math.Pow(y - Y, 2) + Math.Pow(z - Z, 2));
    }
    public static TBall operator *(TBall sphere, double value)
    {
        return new TBall(sphere.X, sphere.Y, sphere.Z, sphere.R * value);
    }
    public static TBall operator *(double value, TBall sphere)
    {
        return new TBall(sphere.X, sphere.Y, sphere.Z, sphere.R * value);
    }
}