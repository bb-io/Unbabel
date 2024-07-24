using Apps.Unbabel.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Unbabel.Models.Request.Translation;

public class SubmitTextTranslationInput
{
    [Display("Text")] public string SourceText { get; set; }

    [Display("Pipeline")]
    [DataSource(typeof(PipelineDataHandler))]
    public string PipelineId { get; set; }
}