namespace Apps.Unbabel.Models.Response.QualityIntelligence;

public class SegmentReportResponse : ReportResponse
{
    public IEnumerable<AnnotationResponse> Annotations { get; set; }
}