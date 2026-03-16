using Microsoft.ML;
using NetGuard.ML.Data;
using NetGuard.ML.Training;

var mlContext = new MLContext(seed: 42);
var loader = new DataLoader(mlContext);
var trainer = new ModelTrainer(mlContext);

var basePath = @"C:\Users\Sov\source\repos\NetGuard";
var trainPath = Path.Combine(basePath, "data", "raw", "KDDTrain+.txt");
var modelPath = Path.Combine(basePath, "data", "processed", "netguard-model.zip");

Console.WriteLine($"Looking for data at: {trainPath}");

Console.WriteLine("=== NetGuard Training Runner ===");
var trainData = loader.LoadData(trainPath);
var model = trainer.TrainFastForest(trainPath);
trainer.SaveModel(model, modelPath, trainData);

Console.WriteLine("Done!");