using Blackbird.Applications.Sdk.Common;

namespace Apps.Unbabel.Models.Request.QualityIntelligence;

public class SegmentEvaluationInput : EvaluationInput
{
    [Display("Source segment")]
    public string SourceSegment { get; set; }
    
    [Display("Target segment")]
    public string TargetSegment { get; set; }
}