using System.Numerics;

namespace Laba2;
class Program
{
    static void Main()
    {
        // double[,] matrix1 = new double[4, 5];
        // double[][] matr = new double[6][];

        // for (int i = 0; i < matr.Length; i++)
        // {
        //     matr[i] = new double[4];
        //     for (int j = 0; j < matr[i].Length; j++)
        //     {
        //         matr[i][j] = 5;
        //     }
        // }

        // for (int i = 0; i < matrix1.GetLength(0); i++)
        // {
        //     for (int j = 0; j < matrix1.GetLength(1); j++)
        //     {
        //         matrix1[i, j] = 1;
        //     }
        // }

        // MyMatrix matrix2 = new MyMatrix(matrix1);
        MyMatrix matrix = new MyMatrix("4\t5\t6\t7\n6\t6\t5\t4\n5\t6\t7\t8\n6\t5\t4\t2");
        // 4\t5\t6\t7\n
        // 6\t6\t5\t4\n
        // 5\t6\t7\t8\n
        // 6\t5\t4\t2
        Console.WriteLine(matrix);
        System.Console.WriteLine(matrix.GetTransponedCopy());
        // System.Console.WriteLine(matrix2);
        // matrix = new MyMatrix(matrix2); // 1 1 1 1
        // System.Console.WriteLine("matrix copy of matrix2:");
        // System.Console.WriteLine(matrix); // 1 1 1 1
        // matrix2 = new MyMatrix(matr); // 5 5 5 5
        // System.Console.WriteLine("second matrix output");
        // System.Console.WriteLine(matrix); // 1 1 1 1 1
        // System.Console.WriteLine();
        // System.Console.WriteLine(matrix2); // 5 5 5 5 5
        // matrix1[1, 1] = 2;
        // matrix1[2, 2] = 3;
        // matrix1[3, 3] = 4;
        // System.Console.WriteLine(matrix2);
        // matrix2 = new MyMatrix(matrix1);
        // System.Console.WriteLine(matrix2);
        // System.Console.WriteLine(matrix1[1, 1]);
        // System.Console.WriteLine();
        // MyMatrix matr1 = new MyMatrix(matr);
        // System.Console.WriteLine(matr1);
        // matr[0][0] = 100;
        // System.Console.WriteLine();
        // System.Console.WriteLine(matr1);
        // System.Console.WriteLine(matr[0][0]);
    }
}