/// <summary>
/// Mean Squared Error (MSE)
/// </summary>
public static class Loss 
{
    public static double MSE(Matrix yTrue, Matrix yPred)
    {
        double sum = 0;
        for (int i = 0; i < yTrue.Rows; i++)
            for (int j = 0; j < yTrue.Cols; j++)
            {
               double diff = yTrue.Data[i, j] - yPred.Data[i, j];
               sum += diff * diff;
            }
        return sum / (yTrue.Rows * yTrue.Cols);
    }
}