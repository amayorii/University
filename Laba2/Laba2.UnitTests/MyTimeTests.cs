using System;

namespace Laba2.UnitTests;

public class MyTimeTests
{
    [Fact]
    public void Ctor_ValidTime_Equal()
    {
        MyTime mt = new MyTime(h: 6, s: 59);
        Assert.Equal((mt.Hour, mt.Minute, mt.Second), (6, 0, 59));
    }
    [Fact]
    public void Ctor_InvalidTime_NotEqual()
    {
        MyTime mt = new MyTime(10);
        Assert.NotEqual((mt.Hour, mt.Minute, mt.Second), (10, -5, 4));
    }
    [Fact]
    public void Ctor_InvalidParams_ThrowsExc()
    {
        Assert.ThrowsAny<Exception>(() => new MyTime(23, -59, 59));
        Assert.ThrowsAny<Exception>(() => new MyTime(0, 0, 60));
        Assert.ThrowsAny<Exception>(() => new MyTime(24, 0, 0));
    }
    [Fact]
    public void Ctor_Empty_000()
    {
        MyTime mt = new MyTime();
        Assert.Equal((mt.Hour, mt.Minute, mt.Second), (0, 0, 0));
    }
    [Fact]
    public void TimeSinceMidnight_Overflow1sec_Equal()
    {
        MyTime mt1 = MyTime.TimeSinceMidnight(86401);
        Assert.Equal(1, MyTime.TimeSinceMidnight(mt1));
    }
    [Fact]
    public void AddMethods_Invoke_Equal()
    {
        MyTime mt = new MyTime(0, 58, 59);
        mt.AddOneSecond();
        mt.AddOneMinute();
        mt.AddOneHour();
        Assert.Equal((2, 0, 0), (mt.Hour, mt.Minute, mt.Second));
    }
    [Fact]
    public void Difference_OneHourDiff_Equal()
    {
        MyTime mt1 = new MyTime(18, 30);
        MyTime mt2 = new MyTime(17, 30);
        Assert.Equal(3600, MyTime.Difference(mt1, mt2));
    }
    [Fact]
    public void WhatLesson_DifferentLessons_Equal()
    {
        MyTime mt1 = new MyTime(05, 48, 0);
        MyTime mt2 = new MyTime(8, 0, 1);
        MyTime mt3 = new MyTime(9, 20);
        MyTime mt4 = new MyTime(9, 40);
        MyTime mt5 = new MyTime(11);
        MyTime mt6 = new MyTime(11, 20);
        MyTime mt7 = new MyTime(12, 40);
        MyTime mt8 = new MyTime(13);
        MyTime mt9 = new MyTime(14, 20);
        MyTime mt10 = new MyTime(14, 40);
        MyTime mt11 = new MyTime(16);
        MyTime mt12 = new MyTime(16, 10);
        MyTime mt13 = new MyTime(23, 06, 05);
        Assert.Equal("lessons didn't begin", MyTime.WhatLesson(mt1));
        Assert.Equal("first lesson", MyTime.WhatLesson(mt2));
        Assert.Equal("break between first and second lessons", MyTime.WhatLesson(mt3));
        Assert.Equal("second lesson", MyTime.WhatLesson(mt4));
        Assert.Equal("break between second and third lessons", MyTime.WhatLesson(mt5));
        Assert.Equal("third lesson", MyTime.WhatLesson(mt6));
        Assert.Equal("break between third and fourth lessons", MyTime.WhatLesson(mt7));
        Assert.Equal("fourth lesson", MyTime.WhatLesson(mt8));
        Assert.Equal("break between fourth and fifth lessons", MyTime.WhatLesson(mt9));
        Assert.Equal("fifth lesson", MyTime.WhatLesson(mt10));
        Assert.Equal("break between fifth and sixth lessons", MyTime.WhatLesson(mt11));
        Assert.Equal("sixth lesson", MyTime.WhatLesson(mt12));
        Assert.Equal("lessons are over", MyTime.WhatLesson(mt13));
    }
}
