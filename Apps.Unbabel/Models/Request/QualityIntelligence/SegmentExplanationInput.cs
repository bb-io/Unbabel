using Blackbird.Applications.Sdk.Common;

namespace Apps.Unbabel.Models.Request.QualityIntelligence;

public class SegmentExplanationInput : ExplanationInput
{
    [Display("Source segment")]
    public string SourceSegment { get; set; }
    
    [Display("Target segment")]
    public string TargetSegment { get; set; }
    
    [Display("Error start position")]
    public int Start { get; set; }
    
    [Display("Error end position")]
    public int End { get; set; }
}