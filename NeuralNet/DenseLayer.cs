public class DenseLayer
{
    public Matrix Weights;
    public Matrix Bias;

    public Matrix Input;
    public Matrix Output;

    public DenseLayer(int inputSize, int outputSize)
    {
        Weights = Matrix.Random(inputSize, outputSize);
        Bias = Matrix.Random(1, outputSize);
    }

    public Matrix Forward(Matrix input)
    {
        Input = input;
        Output = Matrix.Dot(input, Weights);
        Output = Matrix.Add(Output, Bias);
        return Output;
    }

    public (Matrix dInput, Matrix dW, Matrix dB) Backward(Matrix dOutput)
    {
        var dW = Matrix.Dot(Matrix.Transpose(Input), dOutput);
        var dB = dOutput; // Assuming batch size of 1 for simplicity
        var dInput = Matrix.Dot(dOutput, Matrix.Transpose(Weights));

        return (dInput, dW, dB);
    }

    public void Update(Matrix dW, Matrix dB, double lr)
    {
        for (int i = 0; i < Weights.Rows; i++)
        {
            for (int j = 0; j < Weights.Cols; j++)
            {
                Weights.Data[i, j] -= lr * dW.Data[i, j];
            }
        }
        for (int i = 0; i < Bias.Rows; i++)
        {
            for (int j = 0; j < Bias.Cols; j++)
            {
                Bias.Data[i, j] -= lr * dB.Data[i, j];
            }
        }
    }
}