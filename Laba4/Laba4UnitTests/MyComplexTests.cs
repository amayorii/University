using System;

namespace Laba4UnitTests;

public class MyComplexTests
{
    [Fact]
    public void Add_Invoke_Equal()
    {
        MyComplex first = new MyComplex(7, 5);
        MyComplex second = new MyComplex(-4, 4.2);
        MyComplex what = first.Add(second);
        Assert.Equal("3 + 9,2i", what.ToString());
    }

    [Fact]
    public void Subtract_Invoke_Equal()
    {
        MyComplex first = new MyComplex(7, 5);
        MyComplex second = new MyComplex(-4, 4.2);
        MyComplex what = first.Subtract(second);
        Assert.Equal("11 + 0,7999999999999998i", what.ToString());
    }

    [Fact]
    public void Multiply_Invoke_Equal()
    {
        MyComplex first = new MyComplex(7, 5);
        MyComplex second = new MyComplex(-4, 4.2);
        MyComplex what = first.Multiply(second);
        Assert.Equal("-49 + 9,400000000000002i", what.ToString());
    }

    [Fact]
    public void Divide_Invoke_Equal()
    {
        MyComplex first = new MyComplex(7, 5);
        MyComplex second = new MyComplex(-4, 4.2);
        MyComplex what = first.Divide(second);
        // 33.64
        Assert.Equal("-0,2080856123662307 + -1,4684898929845425i", what.ToString());
    }
}
