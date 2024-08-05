using Blackbird.Applications.Sdk.Common;

namespace Apps.Unbabel.Models.Response.QualityIntelligence;

public class EvaluationResponse
{
    [Display("Document report")]
    public ReportResponse DocumentReport { get; set; }
    
    [Display("Segments report")]
    public IEnumerable<SegmentReportResponse> SegmentsReport { get; set; }
    
    [Display("UID")]
    public string? Uid { get; set; }
}