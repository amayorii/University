namespace Laba4UnitTests;
public class MyFracTest
{
    [Fact]
    public void Ctor_ZeroDenominator_ThrowsExc()
    {
        Assert.ThrowsAny<Exception>(() => new MyFrac(4, 0));
    }
    [Fact]
    public void Add_Invoke_Equal()
    {
        MyFrac first = new(3, 3);
        MyFrac second = new(5, 8);
        MyFrac what = first.Add(second);
        Assert.Equal("39/24", what.ToString());
    }
    [Fact]
    public void Subtract_Invoke_Equal()
    {
        MyFrac first = new(3, 3);
        MyFrac second = new(5, 8);
        MyFrac what = first.Subtract(second);
        Assert.Equal("9/24", what.ToString());
    }
    [Fact]
    public void Multiply_Invoke_Equal()
    {
        MyFrac first = new(3, 3);
        MyFrac second = new(5, 8);
        MyFrac what = first.Multiply(second);
        Assert.Equal("15/24", what.ToString());
    }
    [Fact]
    public void Divide_Invoke_Equal()
    {
        MyFrac first = new(3, 3);
        MyFrac second = new(5, 8);
        MyFrac what = first.Divide(second);
        Assert.Equal("24/15", what.ToString());
    }
    [Fact]
    public void CompareTo_Sorting_ByDescending()
    {
        MyFrac a = new MyFrac(1, 3);
        MyFrac b = new MyFrac(1, 6);
        MyFrac c = new MyFrac(1, 2);
        MyFrac d = new MyFrac(8, 2);
        MyFrac e = new MyFrac(0, 10);
        MyFrac[] myFracs = [a, b, c, d, e];
        MyFrac[] correct = [e, b, a, c, d];
        Array.Sort(myFracs);
        Assert.Equal(correct, myFracs);
    }
}