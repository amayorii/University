using System;

namespace Laba2;

public partial class MyMatrix
{
    public static MyMatrix operator +(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.Width != matrix2.Width || matrix1.Height != matrix2.Height) throw new Exception("Matrixes must be the same!");
        MyMatrix matrix3 = new MyMatrix(new double[matrix1.Height, matrix1.Width]);
        for (int i = 0; i < matrix1.Height; i++)
        {
            for (int j = 0; j < matrix1.Width; j++)
            {
                matrix3.SetMatrixElement(i, j, matrix1[i, j] + matrix2[i, j]);
            }
        }
        return matrix3;
    }

    public static MyMatrix operator *(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.Width != matrix2.Height) throw new Exception("Matrix A rows must equal matrix B cols");
        MyMatrix matrix3 = new MyMatrix(new double[matrix1.Height, matrix2.Width]);
        for (int i = 0; i < matrix1.matrixElems.GetLength(0); i++)
        {
            for (int j = 0; j < matrix2.matrixElems.GetLength(1); j++)
            {
                for (int k = 0; k < matrix2.matrixElems.GetLength(0); k++)
                {
                    matrix3[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }
        return matrix3;
    }

    protected double[,] GetTransponedArray()
    {
        double[,] transponedArray = new double[Width, Height];
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                transponedArray[j, i] = matrixElems[i, j];
            }
        }
        return transponedArray;
    }
    public MyMatrix GetTransponedCopy() => new(GetTransponedArray());
    public void TransponeMe() => matrixElems = GetTransponedArray();

}
