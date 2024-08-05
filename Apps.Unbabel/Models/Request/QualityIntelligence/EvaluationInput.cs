using Apps.Unbabel.DataSourceHandlers.StaticHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Unbabel.Models.Request.QualityIntelligence;

public class EvaluationInput
{
    [Display("UID")]
    public string? Uid { get; set; }
    
    [Display("Evaluate within document context")]
    public bool? EvaluateWithinDocumentContext { get; set; }
    
    [Display("Error span precision level")]
    [StaticDataSource(typeof(ErrorSpanPrecisionLevelStaticHandler))]
    public string? ErrorSpanPrecisionLevel { get; set; }
    
    [Display("Score computation method")]
    [StaticDataSource(typeof(ScoreComputationMethodStaticHandler))]
    public string? ScoreComputationMethod { get; set; }
    
    [Display("Register")]
    [StaticDataSource(typeof(RegisterStaticHandler))]
    public string? Register { get; set; }
    
    [Display("Source language")]
    [StaticDataSource(typeof(LanguageStaticHandler))]
    public string? SourceLanguage { get; set; }
    
    [Display("Target language")]
    [StaticDataSource(typeof(LanguageStaticHandler))]
    public string? TargetLanguage { get; set; }
}