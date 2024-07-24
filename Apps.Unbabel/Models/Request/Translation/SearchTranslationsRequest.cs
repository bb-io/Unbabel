using Apps.Unbabel.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Unbabel.Models.Request.Translation;

public class SearchTranslationsRequest
{
    [Display("Source language")]
    public string? SourceLanguage { get; set; }

    [Display("Target language")]
    public string? TargetLanguage { get; set; }

    [Display("Text format")]
    public string? TextFormat { get; set; }
    
    [Display("Pipeline ID")]
    [DataSource(typeof(PipelineDataHandler))]
    public string? PipelineId { get; set; }
}