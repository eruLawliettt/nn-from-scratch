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
}