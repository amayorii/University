namespace scndproject;
public class TTriangle
{
    protected double a, b, c;
    public TTriangle(double a, double b, double c)
    {
        CanExist(a, b, c);
        this.a = a;
        this.b = b;
        this.c = c;
    }
    public TTriangle()
    {
        Input();
    }
    public static bool CanExist(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0) throw new ZeroOrNegativeNumberException("Triangle's sides need to be greater than 0 cm");
        else if (a + b <= c || b + c <= a || a + c <= b) throw new CantExistException("Triangle can't exist");
        return true;
    }
    public double this[char v]
    {
        get { return v == 'A' ? a : v == 'B' ? b : v == 'C' ? c : -1; }
        set
        {
            if (v == 'A' && CanExist(value, b, c)) a = value;
            else if (v == 'B' && CanExist(a, value, c)) b = value;
            else if (v == 'C' && CanExist(a, b, value)) c = value;
            else throw new SideAccessingException("You have access only to A, B and C sides");
        }
    }
    void Input()
    {
        System.Console.Write("Enter the lengths of the sides of the triangle: ");
        double[] args = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToDouble);
        a = args[0];
        b = args[1];
        c = args[2];
        CanExist(a, b, c);
    }
    public void Output()
    {
        System.Console.WriteLine("Sides length: {0} cm {1} cm {2} cm\nArea: {3} cm²\nPerimeter: {4}", a, b, c, GetArea(), GetPerimeter());
    }

    public override string ToString()
    {
        return string.Format($"Sides length: {a} cm {b} cm {c} cm\nArea: {GetArea()} cm²\nPerimeter: {GetPerimeter()} cm");
    }
    public double GetPerimeter()
    {
        double perimeter = this.a + this.b + this.c;
        return perimeter;
    }
    public double GetArea()
    {
        double p = (a + b + c) * 0.5;
        double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        return area;
    }
}