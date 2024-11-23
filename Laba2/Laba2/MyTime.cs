using System.Net;
using System.Security.Cryptography;

namespace Laba2;
public class MyTime
{
    private int hour, minute, second;
    public int Hour
    {
        get => hour;
        set => hour = value < 0 || value > 23 ? throw new Exception("hours must be in a range from 0 to 23") : value;
    }
    public int Minute
    {
        get => minute;
        set => minute = value < 0 || value > 59 ? throw new Exception("minutes must be in a range from 0 to 59") : value;
    }
    public int Second
    {
        get => second;
        set => second = value < 0 || value > 59 ? throw new Exception("seconds must be in a range from 0 to 59") : value;
    }

    public MyTime(int h = 0, int m = 0, int s = 0) => (Hour, Minute, Second) = (h, m, s);

    public override string ToString() => DateTime.Parse($"{hour}:{minute}:{second}")
                                        .ToString("T", new System.Globalization.CultureInfo("en-US"));
    public static int TimeSinceMidnight(MyTime t) => t.hour * 3600 + t.minute * 60 + t.second;

    public static MyTime TimeSinceMidnight(int t)
    {
        int secPerDay = 86400;
        t %= secPerDay;
        t += t < 0 ? secPerDay : 0;
        int h = t / 3600;
        int m = t / 60 % 60;
        int s = t % 60;
        return new MyTime(h, m, s);
    }
    public void AddSeconds(int s)
    {
        s += TimeSinceMidnight(this);
        int secPerDay = 86400;
        s %= secPerDay;
        s += s < 0 ? secPerDay : 0;
        Hour = s / 3600;
        Minute = s / 60 % 60;
        Second = s % 60;
    }
    public void AddOneSecond() => AddSeconds(1);
    public void AddOneMinute() => AddSeconds(60);
    public void AddOneHour() => AddSeconds(3600);
    public static int Difference(MyTime mt1, MyTime mt2) => TimeSinceMidnight(mt1) - TimeSinceMidnight(mt2);

    public static string WhatLesson(MyTime mt)
    {
        return TimeSinceMidnight(mt) switch
        {
            < 28800 => "lessons didn't begin",
            >= 28800 and < 33600 => "first lesson",
            >= 33600 and < 34800 => "break between first and second lessons",
            >= 34800 and < 39600 => "second lesson",
            >= 39600 and < 40800 => "break between second and third lessons",
            >= 40800 and < 45600 => "third lesson",
            >= 45600 and < 46800 => "break between third and fourth lessons",
            >= 46800 and < 51600 => "fourth lesson",
            >= 51600 and < 52800 => "break between fourth and fifth lessons",
            >= 52800 and < 57600 => "fifth lesson",
            >= 57600 and < 58200 => "break between fifth and sixth lessons",
            >= 58200 and < 63000 => "sixth lesson",
            _ => "lessons are over",
        };
    }
}