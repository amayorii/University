namespace scndproject;
public class TDisk
{
    double x, y, r;

    public TDisk(double x, double y, double r)
    {
        this.x = x;
        this.y = y;
        this.r = r > 0 ? r : r == 0 ? throw new Exception("radius cannot be 0") : throw new Exception("radius cannot be negative");
    }

    public TDisk()
    {
        Input();
    }

    public TDisk(TDisk obj)
    {
        x = obj.x;
        y = obj.y;
        r = obj.r;
    }

    public double X
    {
        get { return x; }
        set { x = value; }
    }
    public double Y
    {
        get { return y; }
        set { y = value; }
    }
    public double R
    {
        get { return r; }
        set
        {
            if (value > 0) r = value;
            else if (value == 0) throw new Exception("radius cannot be 0");
            else throw new Exception("radius cannot be negative");
        }
    }
    void Input()
    {
        System.Console.Write("R: "); R = Convert.ToDouble(Console.ReadLine());
        System.Console.Write("X: "); X = Convert.ToDouble(Console.ReadLine());
        System.Console.Write("Y: "); Y = Convert.ToDouble(Console.ReadLine());
    }

    public void Output()
    {
        System.Console.WriteLine("\nX: {0}, Y: {1}, Radius: {2} cm\nArea: {3} cm²", X, Y, R, Area());
    }

    public override string ToString()
    {
        return string.Format($"X: {X}, Y: {Y}, Radius: {R} cm\nArea: {Area()} cm²");
    }

    public double Area()
    {
        return Math.PI * R * R;
    }

    public bool DoesPointBelongToCircle(double x, double y)
    {
        return R > Math.Sqrt(Math.Pow(x - X, 2) + Math.Pow(y - Y, 2));
    }

    public static TDisk operator *(TDisk disk, double value)
    {
        return new TDisk(disk.X, disk.Y, disk.R * value);
    }

    public static TDisk operator *(double value, TDisk disk)
    {
        return new TDisk(disk.X, disk.Y, disk.R * value);
    }
}