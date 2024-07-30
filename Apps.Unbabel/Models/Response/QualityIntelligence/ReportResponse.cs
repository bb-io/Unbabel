using Blackbird.Applications.Sdk.Common;

namespace Apps.Unbabel.Models.Response.QualityIntelligence;

public class ReportResponse
{
    [Display("Score")] public double Score { get; set; }

    [Display("Metric")] public string Metric { get; set; }

    [Display("Word count")] public int WordCount { get; set; }

    [Display("Quality CUA bucket")] public string QualityCuaBucket { get; set; }

    [Display("Severity weight")] public double SeverityWeight { get; set; }

    [Display("Error count")] public int ErrorCount { get; set; }

    [Display("Error count (minor)")] public int ErrorCountMinor { get; set; }

    [Display("Error count (major)")] public int ErrorCountMajor { get; set; }

    [Display("Error count (critical)")] public int ErrorCountCritical { get; set; }
}