

// 2 -> Dense(3) -> ReLU -> Dense(1)


var dense1 = new DenseLayer(2, 3);
var relu = new ReLU();
var dense2 = new DenseLayer(3, 1);

var x = new Matrix(1, 2);
x.Data[0, 0] = 1;
x.Data[0, 1] = 2;

var yTrue = new Matrix(1, 1);
yTrue.Data[0, 0] = 1;

var out1 = dense1.Forward(x);
var act1 = relu.Forward(out1);
var yPred = dense2.Forward(act1);

System.Console.WriteLine("Predicted: " + yPred.Data[0, 0]);
System.Console.WriteLine("Loss: " + Loss.MSE(yTrue, yPred));