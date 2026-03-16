using Microsoft.ML;
using Microsoft.ML.Data;
using NetGuard.ML.Data;
using NetGuard.ML.Models;


namespace NetGuard.ML.Training
{
    public class ModelTrainer
    {
        private readonly MLContext _mlContext;
        private DataLoader _dataLoader;
        private DataPreprocessor _preprocessor;

        public ModelTrainer(MLContext mLContext)
        {
            _mlContext = mLContext;
            _dataLoader = new DataLoader(mLContext);
            _preprocessor = new DataPreprocessor(mLContext);
        
        }

        public ITransformer TrainFastForest(string trainDataPath)
        {
            System.Console.WriteLine("Loading training data...");
            var trainData = _dataLoader.LoadData(trainDataPath);

            System.Console.WriteLine("Building pipline...");
            var pipeline = _preprocessor.BuildPipeline()

                
            .Append(_mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy(
    labelColumnName: "Label",
    featureColumnName: "Features"))


                // Convert predicted number back to attack type string
                .Append(_mlContext.Transforms.Conversion.MapKeyToValue(
                    inputColumnName: "PredictedLabel",
                    outputColumnName: "PredictedLabel"));

                
            System.Console.WriteLine("Training model... (this may take a minute)");
            var model = pipeline.Fit(trainData);

            System.Console.WriteLine("Training complete!");
            return model;

        }
        public void SaveModel(ITransformer model, string modelPath , IDataView trainData)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(modelPath)!);
            _mlContext.Model.Save(model, trainData.Schema, modelPath);
            System.Console.WriteLine($"Model saved to {modelPath}");
        
        }
        public ITransformer LoadModel(string modelPath, out DataViewSchema schema)
        {
            return _mlContext.Model.Load(modelPath, out schema);
            
        }


    }
}