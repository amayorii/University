using System;

namespace scndproject.UnitTests;

public class TBallTests
{
    public required Random rnd;

    public TBallTests()
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
        Assert.Throws<Exception>(() => new TBall(Rnd(), Rnd(), Rnd(), rnd.Next(-100, 0)));
    }

    [Fact]
    public void PropertySet_NegativeRadius_ThrowsException()
    {
        TBall ball = new TBall(Rnd(), Rnd(), Rnd(), 1);
        Assert.Throws<Exception>(() => ball.R = rnd.Next(-100, 0));
    }

    [Fact]
    public void Input_ZeroRadius_ThrowsException()
    {
        Assert.Throws<Exception>(() => new TBall(Rnd(), Rnd(), Rnd(), 0));
    }

    [Fact]
    public void PropertySet_ZeroRadius_ThrowsException()
    {
        TBall ball = new TBall(Rnd(), Rnd(), Rnd(), 1);
        Assert.Throws<Exception>(() => ball.R = 0);
    }

    [Fact]
    public void Area_SameArea_ReturnsEqual()
    {
        int number = rnd.Next(1, 101);
        TBall ball = new TBall(1, 1, 1, number);
        Assert.Equal(ball.Area(), Math.PI * number * number * 4, precision: 5);
    }

    [Fact]
    public void Area_OtherArea_DoesntEqual()
    {
        int number = rnd.Next(1, 101);
        TBall ball = new TBall(1, 1, 1, number);
        Assert.NotEqual(ball.Area(), Math.PI * number * 4, precision: 5);
    }

    [Fact]
    public void Volume_SameVolume_ReturnsEqual()
    {
        double number = rnd.Next(1, 101);
        TBall ball = new TBall(1, 1, 1, number);
        Assert.Equal(ball.Volume(), 4.0 / 3.0 * Math.PI * number * number * number, precision: 5);
    }

    [Fact]
    public void Volume_OtherVolume_DoesntEqual()
    {
        double number = rnd.Next(1, 101);
        TBall ball = new TBall(1, 1, 1, number);
        Assert.NotEqual(ball.Volume(), 4.0 * Math.PI * number * number * number, precision: 5);
    }

    [Fact]
    public void DoesPointBelongToSphere_PointBelongs_ReturnsTrue()
    {
        TBall ball = new TBall(1, 1, 1, 10);
        Assert.True(ball.DoesPointBelongToSphere(5, 5, 5));
    }

    [Fact]
    public void DoesPointBelongToSphere_PointDoesntBelong_ReturnsFalse()
    {
        TBall ball = new TBall(1, 1, 1, 6);
        Assert.False(ball.DoesPointBelongToSphere(10, 10, 10));
    }

    [Fact]
    public void RadiusMultiplyOverload_RandomMultiply_ReturnsEqual()
    {
        TBall ball = new TBall(1, 1, 1, 5);
        double value = rnd.Next(1, 11);
        ball *= value;
        ball = value * ball;
        double expected = value * value * 5;
        Assert.Equal(expected, ball.R);
    }
}