namespace Apps.Unbabel.Models.Response.QualityIntelligence;

public class ExplanationSegmentReportResponse : ReportResponse
{
    public string Explanation { get; set; }

    public string Correction { get; set; }

    public IEnumerable<ExplanationAnnotationResponse> Annotations { get; set; }
}