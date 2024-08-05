using Blackbird.Applications.Sdk.Common;

namespace Apps.Unbabel.Models.Entities;

public class TranslationEntity
{
    [Display("Translation UID")]
    public string TranslationUid { get; set; }

    [Display("Source language")]
    public string SourceLanguage { get; set; }

    [Display("Target language")]
    public string TargetLanguage { get; set; }

    [Display("Text format")]
    public string TextFormat { get; set; }

    [Display("Source text")]
    public string SourceText { get; set; }

    [Display("Target text")]
    public string TargetText { get; set; }

    [Display("Status")]
    public string Status { get; set; }

    [Display("Pipeline ID")]
    public string PipelineId { get; set; }
}