using System;
namespace Laba2;

partial class MyMatrix
{
    private readonly double[,] matrixElems;
    public int Height { get; }
    public int Width { get; }

    // constructors
    // copy 
    public MyMatrix(MyMatrix matrix) => matrixElems = (double[,])matrix.matrixElems.Clone();

    // 2-dim arr
    public MyMatrix(double[,] matrix) => matrixElems = (double[,])matrix.Clone();

    // jagged arr
    public MyMatrix(double[][] matrix)
    {
        //TODO IsRectangular(double[][])
        if (IsRectangular(matrix))
        {
            matrixElems = new double[matrix.Length, matrix[0].Length];
            //TODO ConvertFromJaggedArrayToRectangular
            matrixElems = ConvertFromJaggToRect(matrix);
        }
        else throw new Exception("Matrix must be rectangular");
    }

    // arr of strings
    public MyMatrix(string[] strings)
    {
        //TODO IsRectangular(string[])
        if (IsRectangular(strings))
        {
            matrixElems = new double[strings.Length, strings[0].Split(' ').Length];
            //TODO ConvertFromStringArrayToMatrix()
            matrixElems = ConvertFromStrArrToMatrix(strings);
        }
        else throw new Exception("Matrix must be rectangular");
    }

    // string with separators ("\n" & "\t")
    public MyMatrix(string str) : this(str.Replace("\t", " ").Split('\n')) { }

    // getters, setters & indexers
    public int GetHeight() => Height;
    public int GetWidth() => Width;

    // methods 
    private double[,] ConvertFromStrArrToMatrix(string[] strings)
    {
        for (int i = 0; i < strings.Length; i++)
        {
            for (int j = 0; j < strings[i].Split(' ').Length; j++)
            {
                matrixElems[i, j] = Convert.ToInt32(strings[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)[j]);
            }
        }
        return matrixElems;
    }

    private double[,] ConvertFromJaggToRect(double[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                matrixElems[i, j] = matrix[i][j];
            }
        }
        return matrixElems;
    }

    static bool IsRectangular(double[][] matrix) => !matrix.Any(x => x.Length != matrix[0].Length);
    static bool IsRectangular(string[] strings) => !strings.Any(x => x.Length != strings[0].Length);

    override public string ToString()
    {
        string str = null;

        for (int i = 0; i < matrixElems.GetLength(0); i++)
        {
            for (int j = 0; j < matrixElems.GetLength(1); j++)
            {
                str += $"{matrixElems[i, j]}\t";
            }

            str += "\n";
        }
        return str;
    }
}
