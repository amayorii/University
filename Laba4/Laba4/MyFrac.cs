using System.Numerics;
using System.Reflection.Metadata;

class MyFrac : IMyNumber<MyFrac>
{
    readonly BigInteger numerator;
    readonly BigInteger denominator;

    public MyFrac(BigInteger numerator, BigInteger denominator)
    {
        this.numerator = numerator;
        CheckForZero(denominator);
        this.denominator = denominator;
    }

    public MyFrac(long numerator, long denominator)
    {
        this.numerator = numerator;
        CheckForZero(denominator);
        this.denominator = denominator;
    }

    public MyFrac(int numerator, int denominator)
    {
        this.numerator = numerator;
        CheckForZero(denominator);
        this.denominator = denominator;
    }

    public MyFrac(short numerator, short denominator)
    {
        this.numerator = numerator;
        CheckForZero(denominator);
        this.denominator = denominator;
    }

    public MyFrac(byte numerator, byte denominator)
    {
        this.numerator = numerator;
        CheckForZero(denominator);
        this.denominator = denominator;
    }

    public MyFrac()
    {
        numerator = 1;
        denominator = 2;
    }
    private static void CheckForZero(object denominator)
    {
        if (denominator.ToString() == "0") throw new DivideByZeroException("denominator cannot be 0");
    }

    public MyFrac Add(MyFrac another)
    {
        return new MyFrac(numerator * another.denominator + another.numerator * denominator, denominator * another.denominator);
    }

    public MyFrac Subtract(MyFrac another)
    {
        return new MyFrac(numerator * another.denominator - another.numerator * denominator, denominator * another.denominator);
    }

    public MyFrac Multiply(MyFrac another)
    {
        return new MyFrac(numerator * another.numerator, denominator * another.denominator);
    }

    public MyFrac Divide(MyFrac another)
    {
        return new MyFrac(numerator * another.denominator, denominator * another.numerator);
    }

    public override string ToString()
    {
        return $"";
    }
}