
var dense1 = new DenseLayer(2, 3);
var relu = new ReLU();
var dense2 = new DenseLayer(3, 1);

var x = new Matrix(1, 2);
x.Data[0, 0] = 1;
x.Data[0, 1] = 2;

var yTrue = new Matrix(1, 1);
yTrue.Data[0, 0] = 1;

double lr = 0.01;

for (int epoch = 1; epoch <= 300; epoch++)
{
    var out1 = dense1.Forward(x);
    var act1 = relu.Forward(out1);
    var yPred = dense2.Forward(act1);

    var loss = Loss.MSE(yTrue, yPred);

    var error = Matrix.Substract(yPred, yTrue);

    var (dAct1, dW2, dB2) = dense2.Backward(error);

    var dOut1 = relu.Backward(out1, dAct1);

    var (dInput, dW1, dB1) = dense1.Backward(dOut1);

    dense2.Update(dW2, dB2, lr);
    dense1.Update(dW1, dB1, lr);

    System.Console.WriteLine($"Epoch {epoch}, Prediction: {yPred.Data[0, 0]}, Loss: {loss}");
}





