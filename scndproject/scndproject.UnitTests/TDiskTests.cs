using System;

namespace scndproject.UnitTests;

public class TDiskTests
{
    public required Random rnd;
    public TDiskTests()
    {
        rnd = new Random();
    }
    int Rnd()
    {
        return rnd.Next(-100, 101);
    }

    [Fact]
    public void Input_NegativeRadius_ThrowsException()
    {
        Assert.Throws<Exception>(() => new TDisk(Rnd(), Rnd(), rnd.Next(-100, 0)));
    }

    [Fact]
    public void PropertySet_NegativeRadius_ThrowsException()
    {
        TDisk disk = new TDisk(Rnd(), Rnd(), 1);
        Assert.Throws<Exception>(() => disk.R = rnd.Next(-100, 0));
    }

    [Fact]
    public void Input_ZeroRadius_ThrowsException()
    {
        Assert.Throws<Exception>(() => new TDisk(Rnd(), Rnd(), 0));
    }

    [Fact]
    public void PropertySet_ZeroRadius_ThrowsException()
    {
        TDisk disk = new TDisk(Rnd(), Rnd(), 1);
        Assert.Throws<Exception>(() => disk.R = 0);
    }

    [Fact]
    public void Area_SameArea_ReturnsEqual()
    {
        int number = rnd.Next(1, 101);
        TDisk disk = new TDisk(Rnd(), Rnd(), number);
        Assert.Equal(disk.Area(), Math.PI * number * number, precision: 5);
    }

    [Fact]
    public void Area_OtherArea_DoesntEqual()
    {
        int number = rnd.Next(1, 101);
        TDisk disk = new TDisk(Rnd(), Rnd(), number);
        Assert.NotEqual(disk.Area(), Math.PI * number, precision: 5);
    }

    [Fact]
    public void DoesPointBelongToCircle_PointBelongs_ReturnsTrue()
    {
        TDisk disk = new TDisk(1, 1, 10);
        Assert.True(disk.DoesPointBelongToCircle(5, 5));
    }

    [Fact]
    public void DoesPointBelongToCircle_PointDoesntBelong_ReturnsFalse()
    {
        TDisk disk = new TDisk(1, 1, 6);
        Assert.False(disk.DoesPointBelongToCircle(10, 10));
    }

    [Fact]
    public void RadiusMultiplyOverload_RandomMultiply_ReturnsEqual()
    {
        TDisk disk = new TDisk(Rnd(), Rnd(), 5);
        double value = rnd.Next(1, 11);
        disk *= value;
        disk = value * disk;
        double expected = value * value * 5;
        Assert.Equal(expected, disk.R);
    }
}