using Apps.Unbabel.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Unbabel.Models.Request.Translation;

public class SubmitFileTranslationInput
{
    [Display("File", Description = "Only txt, html and xliff supported")]
    public FileReference File { get; set; }

    [Display("Pipeline")]
    [DataSource(typeof(PipelineDataHandler))]
    public string PipelineId { get; set; }
}