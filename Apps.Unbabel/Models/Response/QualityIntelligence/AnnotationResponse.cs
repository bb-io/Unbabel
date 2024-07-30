using Blackbird.Applications.Sdk.Common;

namespace Apps.Unbabel.Models.Response.QualityIntelligence;

public class AnnotationResponse
{
    [Display("Error description")] public string Error { get; set; }

    [Display("Start position")] public int Start { get; set; }

    [Display("End position")] public int End { get; set; }

    [Display("Severity level")] public string Severity { get; set; }

    [Display("Weight")] public double Weight { get; set; }
}