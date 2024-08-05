namespace Apps.Unbabel.Models.Request.QualityIntelligence;

public class EvaluateTranslationRequest
{
    public string? Uid { get; set; }

    public bool? EvaluateWithinDocumentContext { get; set; }

    public string? ErrorSpanPrecisionLevel { get; set; }

    public string? ScoreComputationMethod { get; set; }

    public string? Register { get; set; }

    public string? SourceLanguage { get; set; }

    public string? TargetLanguage { get; set; }

    public IEnumerable<TranslatedSegment> TranslatedSegments { get; set; }

    public EvaluateTranslationRequest(EvaluationInput input, IEnumerable<TranslatedSegment> segments)
    {
        Uid = input.Uid;
        EvaluateWithinDocumentContext = input.EvaluateWithinDocumentContext;
        ErrorSpanPrecisionLevel = input.ErrorSpanPrecisionLevel;
        ScoreComputationMethod = input.ScoreComputationMethod;
        Register = input.Register;
        SourceLanguage = input.SourceLanguage;
        TargetLanguage = input.TargetLanguage;
        TranslatedSegments = segments;
    }
}