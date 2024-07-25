namespace Apps.Unbabel.Models.Request.QualityIntelligence;

public class ExplainTranslationRequest
{
    public string? Uid { get; set; }

    public string? Register { get; set; }

    public string? SourceLanguage { get; set; }

    public string? TargetLanguage { get; set; }

    public IEnumerable<TranslatedSegment> TranslatedSegments { get; set; }

    public ExplainTranslationRequest(ExplanationInput input, IEnumerable<TranslatedSegment> segments)
    {
        Uid = input.Uid;
        Register = input.Register;
        SourceLanguage = input.SourceLanguage;
        TargetLanguage = input.TargetLanguage;
        TranslatedSegments = segments;
    }
}