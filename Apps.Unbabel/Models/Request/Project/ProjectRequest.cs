using Apps.Unbabel.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Unbabel.Models.Request.Project;

public class ProjectRequest
{
    [Display("Project ID")]
    [DataSource(typeof(ProjectDataHandler))]
    public string ProjectId { get; set; }
}