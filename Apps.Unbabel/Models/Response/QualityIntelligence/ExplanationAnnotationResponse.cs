namespace Apps.Unbabel.Models.Response.QualityIntelligence;

public class ExplanationAnnotationResponse : AnnotationResponse
{
    public string Source { get; set; }

    public string Category { get; set; }

    public string Explanation { get; set; }

    public string Correction { get; set; }
}