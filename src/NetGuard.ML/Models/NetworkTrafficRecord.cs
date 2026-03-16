using Microsoft.ML.Data;

namespace NetGuard.ML.Models
{
    public class NetworkTrafficRecord
    {
        [LoadColumn(0)] public float Duration { get; set; }
        [LoadColumn(1)] public string ProtocolType { get; set; } = "";
        [LoadColumn(2)] public string Service { get; set; } = "";
        [LoadColumn(3)] public string Flag { get; set; } = "";
        [LoadColumn(4)] public float SrcBytes { get; set; }
        [LoadColumn(5)] public float DstBytes { get; set; }
        [LoadColumn(6)] public float Land { get; set; }
        [LoadColumn(7)] public float WrongFragment { get; set; }
        [LoadColumn(8)] public float Urgent { get; set; }
        [LoadColumn(9)] public float Hot { get; set; }
        [LoadColumn(10)] public float NumFailedLogins { get; set; }
        [LoadColumn(11)] public float LoggedIn { get; set; }
        [LoadColumn(12)] public float NumCompromised { get; set; }
        [LoadColumn(13)] public float RootShell { get; set; }
        [LoadColumn(14)] public float SuAttempted { get; set; }
        [LoadColumn(15)] public float NumRoot { get; set; }
        [LoadColumn(16)] public float NumFileCreations { get; set; }
        [LoadColumn(17)] public float NumShells { get; set; }
        [LoadColumn(18)] public float NumAccessFiles { get; set; }
        [LoadColumn(19)] public float NumOutboundCmds { get; set; }
        [LoadColumn(20)] public float IsHostLogin { get; set; }
        [LoadColumn(21)] public float IsGuestLogin { get; set; }
        [LoadColumn(22)] public float Count { get; set; }
        [LoadColumn(23)] public float SrvCount { get; set; }
        [LoadColumn(24)] public float SerrorRate { get; set; }
        [LoadColumn(25)] public float SrvSerrorRate { get; set; }
        [LoadColumn(26)] public float RerrorRate { get; set; }
        [LoadColumn(27)] public float SrvRerrorRate { get; set; }
        [LoadColumn(28)] public float SameSrvRate { get; set; }
        [LoadColumn(29)] public float DiffSrvRate { get; set; }
        [LoadColumn(30)] public float SrvDiffHostRate { get; set; }
        [LoadColumn(31)] public float DstHostCount { get; set; }
        [LoadColumn(32)] public float DstHostSrvCount { get; set; }
        [LoadColumn(33)] public float DstHostSameSrvRate { get; set; }
        [LoadColumn(34)] public float DstHostDiffSrvRate { get; set; }
        [LoadColumn(35)] public float DstHostSameSrcPortRate { get; set; }
        [LoadColumn(36)] public float DstHostSrvDiffHostRate { get; set; }
        [LoadColumn(37)] public float DstHostSerrorRate { get; set; }
        [LoadColumn(38)] public float DstHostSrvSerrorRate { get; set; }
        [LoadColumn(39)] public float DstHostRerrorRate { get; set; }
        [LoadColumn(40)] public float DstHostSrvRerrorRate { get; set; }
        [LoadColumn(41)] public string AttackType { get; set; } = "";
        [LoadColumn(42)] public float DifficultyLevel { get; set; }
    }
}