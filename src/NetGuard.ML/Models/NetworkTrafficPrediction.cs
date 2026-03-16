using Microsoft.ML.Data;

namespace NetGuard.ML.Models
{
    public class NetworkTrafficPrediction
    {
        [ColumnName("PredictedLabel")]
        public string PredictedAttackType {get; set;} = "";

        public float [] Score {get; set; } = [];
        
    }
}