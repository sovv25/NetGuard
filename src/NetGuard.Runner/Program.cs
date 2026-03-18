using Microsoft.ML;
using NetGuard.ML.Data;
using NetGuard.ML.Evaluation;
using NetGuard.ML.Training;

var mlContext = new MLContext(seed: 42);
var loader = new DataLoader(mlContext);
var trainer = new ModelTrainer(mlContext);
var evaluator = new ModelEvaluator(mlContext);

var basePath = Path.GetFullPath(Path.Combine(
    AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", ".."));

var trainPath = Path.Combine(basePath, "data", "raw", "KDDTrain+.txt");
var testPath = Path.Combine(basePath, "data", "raw", "KDDTest+.txt");
var modelPath = Path.Combine(basePath, "data", "processed", "netguard-model.zip");
var metricsPath = Path.Combine(basePath, "data", "processed", "metrics.json");

Console.WriteLine("=== NetGuard Training Runner ===");
Console.WriteLine($"Base path: {basePath}");

// Train
var trainData = loader.LoadData(trainPath);
var model = trainer.TrainFastForest(trainPath);
trainer.SaveModel(model, modelPath, trainData);

// Evaluate
evaluator.Evaluate(model, testPath);
evaluator.SaveMetricsToJson(model, testPath, metricsPath);

Console.WriteLine("\nDone!");