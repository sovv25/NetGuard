using Microsoft.ML;
using Microsoft.ML.Data;
using NetGuard.ML.Data;

namespace NetGuard.ML.Evaluation
{
    public class ModelEvaluator
    {
        private readonly MLContext _mlContext;
        private readonly DataLoader _dataLoader;

        public ModelEvaluator(MLContext mlContext)
        {
            _mlContext = mlContext;
            _dataLoader = new DataLoader(mlContext);
        

        }


        public void Evaluate(ITransformer model, string testDataPath)
        {
            System.Console.WriteLine("\n=== Model Evaluation ===");

            var testData = _dataLoader.LoadData(testDataPath);
            var predictions = model.Transform(testData);

            var metrics = _mlContext.MulticlassClassification.Evaluate(
                predictions,
                labelColumnName:"Label",
                predictedLabelColumnName: "PredictedLabel"
            );


            
            Console.WriteLine($"Macro Accuracy:       {metrics.MacroAccuracy:P2}");
            Console.WriteLine($"Micro Accuracy:       {metrics.MicroAccuracy:P2}");
            Console.WriteLine($"Log Loss:             {metrics.LogLoss:F4}");
            Console.WriteLine($"Log Loss Reduction:   {metrics.LogLossReduction:F4}");
        
            Console.WriteLine("\n--- Per Class Metrics ---");
            Console.WriteLine(metrics.ConfusionMatrix.GetFormattedConfusionTable());
        }

        public void SaveMetricsToJson(ITransformer model, string testDataPath, string outputPath)
        {
            var testData = _dataLoader.LoadData(testDataPath);
            var predictions = model.Transform(testData);

            var metrics = _mlContext.MulticlassClassification.Evaluate(
                predictions,
                labelColumnName: "Label",
                predictedLabelColumnName: "PredictedLabel"); 
            
            var result = new
            {
               MacroAccuracy = metrics.MacroAccuracy,
               MicroAccuracy = metrics.MicroAccuracy,
               LogLoss = metrics.LogLoss,
               LogLossReduction = metrics.LogLossReduction,
               EvaluatedAt = DateTime.UtcNow.ToString("o")  
            };

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);
            var json = System.Text.Json.JsonSerializer.Serialize(result,
            new System.Text.Json.JsonSerializerOptions{ WriteIndented = true});
            
            File.WriteAllText(outputPath, json);
            System.Console.WriteLine($"\nMetrics saved to {outputPath}");

        }
    } 
}