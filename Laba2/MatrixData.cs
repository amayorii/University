using System;
using System.Text;
namespace Laba2;

public partial class MyMatrix
{
    private double[,] matrixElems;
    public int Height { get { return matrixElems.GetLength(0); } }
    public int Width { get { return matrixElems.GetLength(1); } }


    // constructors
    // copy 
    public MyMatrix(MyMatrix matrix) : this(matrix.matrixElems) { }

    // 2-dim arr
    public MyMatrix(double[,] matrix) => matrixElems = (double[,])matrix.Clone();

    // jagged arr
    public MyMatrix(double[][] matrix)
    {
        IsRectangular(matrix);
        matrixElems = new double[matrix.Length, matrix[0].Length];
        matrixElems = ConvertFromJaggToRect(matrix);
    }

    // arr of strings
    public MyMatrix(string[] strings)
    {
        IsRectangular(strings);
        matrixElems = new double[strings.Length, strings[0].Split(' ').Length];
        matrixElems = ConvertFromStrArrToMatrix(strings);
    }

    // string with separators ("\n" & "\t")
    public MyMatrix(string str) : this(str.Replace("\t", " ").Split('\n', StringSplitOptions.RemoveEmptyEntries)) { }


    // getters, setters & indexers
    public int GetHeight() => Height;
    public int GetWidth() => Width;

    public double this[int i, int j]
    {
        get
        {
            AreValidIndexes(i, j);
            return matrixElems[i, j];
        }
        set
        {
            AreValidIndexes(i, j);
            matrixElems[i, j] = value;
        }
    }
    public double GetMatrixElement(int row, int col)
    {
        AreValidIndexes(row, col);
        return matrixElems[row, col];
    }
    public void SetMatrixElement(int row, int col, double value)
    {
        AreValidIndexes(row, col);
        matrixElems[row, col] = value;
    }
    bool AreValidIndexes(int i, int j) => (i > Height || i < 0 || j > Width || j < 0) ? throw new IndexOutOfRangeException($"Matrix has a size {Height}x{Width}") : true;

    // methods 
    private double[,] ConvertFromStrArrToMatrix(string[] strings)
    {
        foreach (var str in strings)
        {
            if (str.Any(char.IsLetter)) throw new Exception("String must only contain numbers!");
        }

        for (int i = 0; i < strings.Length; i++)
        {
            for (int j = 0; j < strings[0].Split(' ').Length; j++)
            {
                matrixElems[i, j] = Convert.ToDouble(strings[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)[j]);
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

    static bool IsRectangular(double[][] matrix) => !matrix.Any(x => x.Length != matrix[0].Length) ? true : throw new Exception("Matrix must be rectangular");
    static bool IsRectangular(string[] strings) => !strings.Any(x => x.Split(' ').Length != strings[0].Split(' ').Length) ? true : throw new Exception("Matrix must be rectangular");

    override public string ToString()
    {
        StringBuilder str = new();

        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
                str.Append($"{matrixElems[i, j]}\t");
            str.Remove(str.Length - 1, 1);
            str.Append('\n');
        }

        return str.Remove(str.Length - 1, 1).ToString();
    }
}
