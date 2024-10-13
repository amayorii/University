using System;
namespace Laba2;

partial class MyMatrix
{
    private readonly double[,] matrixElems;
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

}
