﻿using System.Numerics;

namespace Laba4;

class Program
{
    static void testAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
    {
        Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
        T aPlusB = a.Add(b);
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
        Console.WriteLine("(a + b) = " + aPlusB);
        Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
        Console.WriteLine(" = = = ");
        T curr = a.Multiply(a);
        Console.WriteLine("a^2 = " + curr);
        T wholeRightPart = curr;
        curr = a.Multiply(b);  // ab
        curr = curr.Add(curr); // ab + ab = 2ab
                               // I’m not sure how to create constant factor "2" in more elegant way,
                               // without knowing how IMyNumber is implemented
        Console.WriteLine("2*a*b = " + curr);
        wholeRightPart = wholeRightPart.Add(curr);
        curr = b.Multiply(b);
        Console.WriteLine("b^2 = " + curr);
        wholeRightPart = wholeRightPart.Add(curr);
        Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
        Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
    }

    static void Main()
    {
        testAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
        testAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));
        MyFrac a = new MyFrac(1, 3);
        MyFrac b = new MyFrac(1, 6);
        MyFrac c = new MyFrac(1, 2);
        MyFrac[] myFracs = [a, b, c];
        Array.Sort(myFracs);
        foreach (var item in myFracs)
        {
            System.Console.WriteLine(item);
        }
    }
}
