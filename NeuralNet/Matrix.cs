using System.Runtime.ExceptionServices;

public class Matrix
{
    public int Rows;
    public int Cols;
    public double[,] Data;

    public Matrix(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
        Data = new double[rows, cols];
    }

    public static Matrix Random(int rows, int cols)
    {
        var rnd = new Random();
        var m = new Matrix(rows, cols);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                m.Data[i, j] = rnd.NextDouble() * 2 - 1; // Random values between -1 and 1
            }
        }
        return m;
    }

    public static Matrix Dot(Matrix a, Matrix b)
    {
        if (a.Cols != b.Rows)
            throw new Exception("Incompatible matrix sizes for multiplication.");

        var result = new Matrix(a.Rows, b.Cols);
        for (int i = 0; i < result.Rows; i++)
        {
            for (int j = 0; j < result.Cols; j++)
            {
                double sum = 0;
                for (int k = 0; k < a.Cols; k++)
                    sum += a.Data[i, k] * b.Data[k, j];

                result.Data[i, j] = sum;
            }
        }
        return result;
    }

    public static Matrix Add(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Cols != b.Cols)
            throw new Exception("Incompatible matrix sizes for addition.");

        var result = new Matrix(a.Rows, a.Cols);
        for (int i = 0; i < result.Rows; i++)
        {
            for(int j = 0; j < result.Cols; j++)
            {
                result.Data[i, j] = a.Data[i, j] + b.Data[i, j];
            }
        }
        return result;
    }

    public static Matrix Substract(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Cols != b.Cols)
            throw new Exception("Incompatible matrix sizes for subtraction.");

        var result = new Matrix(a.Rows, a.Cols);
        for (int i = 0; i < result.Rows; i++)
        {
            for (int j = 0; j < result.Cols; j++)
            {
                result.Data[i, j] = a.Data[i, j] - b.Data[i, j];
            }
        }
        return result;
    }

    public static Matrix Transpose(Matrix m)
    {
        var result = new Matrix(m.Cols, m.Rows);
        for (int i = 0; i < m.Rows; i++)
        {
            for (int j = 0; j < m.Cols; j++)
            {
                result.Data[j, i] = m.Data[i, j];
            }
        }
        return result;
    }
}   