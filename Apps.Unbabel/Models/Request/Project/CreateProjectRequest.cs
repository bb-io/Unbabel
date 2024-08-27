using Apps.Unbabel.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Unbabel.Models.Request.Project;

public class CreateProjectRequest
{
    public string Name { get; set; }
    
    [Display("Pipelines")]
    [DataSource(typeof(PipelineDataHandler))]
    public IEnumerable<string> PipelineIds { get; set; }
    
    [Display("Email of request creator")]
    public string RequestedBy { get; set; }

    [Display("Callback", Description = "Use as URL endpoint for completed translations to be delivered to")]
    public string? Callback { get; set; }
}