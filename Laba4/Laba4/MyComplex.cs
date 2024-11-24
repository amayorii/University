public class MyComplex : IMyNumber<MyComplex>
{
    readonly double real, imaginary;

    public MyComplex(double real, double imaginary)
    {
        this.real = real;
        this.imaginary = imaginary;
    }

    public MyComplex()
    {
        real = 3.14;
        imaginary = -1;
    }

    public MyComplex Add(MyComplex another)
    {
        return new MyComplex(real + another.real, imaginary + another.imaginary);
    }

    public MyComplex Subtract(MyComplex another)
    {
        return new MyComplex(real - another.real, imaginary - another.imaginary);
    }

    public MyComplex Multiply(MyComplex another)
    {
        return new MyComplex(real * another.real - imaginary * another.imaginary,
                             real * another.imaginary + imaginary * another.real);
    }

    public MyComplex Divide(MyComplex another)
    {
        double denom = Math.Pow(another.real, 2) + Math.Pow(another.imaginary, 2);

        return new MyComplex(
            (real * another.real + imaginary * another.imaginary) / denom,
            (imaginary * another.real - real * another.imaginary) / denom
        );
    }

    public override string ToString()
    {
        return $"{real} + {imaginary}i";
    }
}