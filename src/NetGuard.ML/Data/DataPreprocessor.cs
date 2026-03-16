using Microsoft.ML;
using Microsoft.ML.Data;
using NetGuard.ML.Models;

namespace NetGuard.ML.Data
{
    public class DataPreprocessor
    {
        private readonly MLContext _mlContext;

        public DataPreprocessor(MLContext mlContext)
        {
            _mlContext = mlContext;
        }

        public IEstimator<ITransformer> BuildPipeline()
        {
            var pipeline =
                _mlContext.Transforms.Categorical.OneHotEncoding("ProtocolType")
                .Append(_mlContext.Transforms.Categorical.OneHotEncoding("Service"))
                .Append(_mlContext.Transforms.Categorical.OneHotEncoding("Flag"))
                .Append(_mlContext.Transforms.Conversion.MapValueToKey(
                    inputColumnName: "AttackType",
                    outputColumnName: "Label"))
                .Append(_mlContext.Transforms.Concatenate("Features",
                    "Duration", "ProtocolType", "Service", "Flag",
                    "SrcBytes", "DstBytes", "Land", "WrongFragment", "Urgent",
                    "Hot", "NumFailedLogins", "LoggedIn", "NumCompromised",
                    "RootShell", "SuAttempted", "NumRoot", "NumFileCreations",
                    "NumShells", "NumAccessFiles", "NumOutboundCmds",
                    "IsHostLogin", "IsGuestLogin", "Count", "SrvCount",
                    "SerrorRate", "SrvSerrorRate", "RerrorRate", "SrvRerrorRate",
                    "SameSrvRate", "DiffSrvRate", "SrvDiffHostRate",
                    "DstHostCount", "DstHostSrvCount", "DstHostSameSrvRate",
                    "DstHostDiffSrvRate", "DstHostSameSrcPortRate",
                    "DstHostSrvDiffHostRate", "DstHostSerrorRate",
                    "DstHostSrvSerrorRate", "DstHostRerrorRate",
                    "DstHostSrvRerrorRate"))
                .Append(_mlContext.Transforms.NormalizeMeanVariance("Features"))
                .AppendCacheCheckpoint(_mlContext);

            return pipeline;
        }
    }
}