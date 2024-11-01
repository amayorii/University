using System;

namespace scndproject.UnitTests;

public class TTriangleTests
{
    [Fact]
    public void CanExist_TriangleCanExist_ReturnsTrue()
    {
        Assert.True(TTriangle.CanExist(5, 8, 11));
    }

    [Fact]
    public void CanExist_TriangleCantExist_ThrowsException()
    {
        Assert.Throws<ZeroOrNegativeNumberException>(() => TTriangle.CanExist(5, 4, -1));
    }

    [Fact]
    public void Indexer_CallingOtherIndexes_ThrowsException()
    {
        TTriangle triangle = new TTriangle(4, 5, 6);
        Assert.Throws<SideAccessingException>(() => triangle['V'] = 5);
    }

    [Fact]
    public void GetPerimeter_SamePerimeter_Equals()
    {
        TTriangle triangle = new TTriangle(4, 5, 6);
        Assert.Equal(4 + 5 + 6, triangle.GetPerimeter());
    }

    [Fact]
    public void GetPerimeter_OtherPerimeter_DoesntEqual()
    {
        TTriangle triangle = new TTriangle(4, 5, 6);
        Assert.NotEqual(1 + 3 + 3, triangle.GetPerimeter());
    }

    [Fact]
    public void GetArea_SameArea_Equals()
    {
        TTriangle triangle = new TTriangle(4, 5, 6);
        double p = (4 + 5 + 6) * 0.5;
        double area = Math.Sqrt(p * (p - 4) * (p - 5) * (p - 6));
        Assert.Equal(area, triangle.GetArea());
    }

    [Fact]
    public void GetArea_OtherArea_DoesntEqual()
    {
        TTriangle triangle = new TTriangle(4, 5, 6);
        double p = (1 + 2 + 3) * 0.5;
        double area = Math.Sqrt(p * (p - 4) * (p - 5) * (p - 6));
        Assert.NotEqual(area, triangle.GetArea());
    }
}
