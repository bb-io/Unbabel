namespace Apps.Unbabel.Models.Request.QualityIntelligence;

public class ExplanationTranslatedSegment : TranslatedSegment
{
    public IEnumerable<TargetPartialAnnotation> TargetPartialAnnotations { get; set; }
}