using Microsoft.ML;
using NetGuard.ML.Models;

namespace NetGuard.ML.Data
{
    public class DataLoader
    {
        private readonly MLContext _mlContext;

        public DataLoader(MLContext mlContext)
        {
            _mlContext = mlContext;
        }

        public IDataView LoadData(string filePath)
        {
            return _mlContext.Data.LoadFromTextFile<NetworkTrafficRecord>(
                path: filePath,
                hasHeader: false,
                separatorChar: ','
            );
        }

        public (IDataView trainData, IDataView testData) LoadTrainTestData(
            string trainPath, string testPath)
        {
            var trainData = LoadData(trainPath);
            var testData = LoadData(testPath);
            return (trainData, testData);
        }
    }
}