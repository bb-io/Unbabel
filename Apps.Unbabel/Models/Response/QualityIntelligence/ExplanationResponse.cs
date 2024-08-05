using Blackbird.Applications.Sdk.Common;

namespace Apps.Unbabel.Models.Response.QualityIntelligence;

public class ExplanationResponse
{
    [Display("Document report")]
    public ExplanationReportResponse DocumentReport { get; set; }
    
    [Display("Segments report")]
    public IEnumerable<ExplanationSegmentReportResponse> SegmentsReport { get; set; }
    
    [Display("UID")]
    public string? Uid { get; set; }
}