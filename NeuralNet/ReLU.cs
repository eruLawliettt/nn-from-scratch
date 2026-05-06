public class ReLU
{
    public Matrix Forward(Matrix input)
    {
        var result = new Matrix(input.Rows, input.Cols);

        for (int i = 0; i < input.Rows; i++)
            for (int j = 0; j < input.Cols; j++)
                result.Data[i, j] = Math.Max(0, input.Data[i, j]);

        return result;
    }

    public Matrix Backward(Matrix input, Matrix dOutput)
    {
        var grad = new Matrix(input.Rows, input.Cols);

        for (int i = 0; i < input.Rows; i++)
            for (int j = 0; j < input.Cols; j++)
                grad.Data[i, j] = input.Data[i, j] > 0 ? dOutput.Data[i, j] : 0;

        return grad;
    }
}