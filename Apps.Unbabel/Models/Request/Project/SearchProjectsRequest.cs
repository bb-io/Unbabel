using Apps.Unbabel.DataSourceHandlers;
using Apps.Unbabel.DataSourceHandlers.StaticHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Unbabel.Models.Request.Project;

public class SearchProjectsRequest
{
    public string? Name { get; set; }
    
    [Display("Pipelines")]
    [DataSource(typeof(PipelineDataHandler))]
    public IEnumerable<string>? PipelineIds { get; set; }
    
    [Display("Email of request creator")]
    public IEnumerable<string>? RequestedBy { get; set; }
    
    [StaticDataSource(typeof(ProjectStatusDataHandler))]
    public IEnumerable<string>? Status { get; set; }
}