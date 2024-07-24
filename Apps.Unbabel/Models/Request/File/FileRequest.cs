using Apps.Unbabel.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Unbabel.Models.Request.File;

public class FileRequest
{
    [Display("Project ID")]
    [DataSource(typeof(ProjectDataHandler))]
    public string ProjectId { get; set; }
    
    [Display("File ID")]
    [DataSource(typeof(FileDataHandler))]
    public string FileId { get; set; }
}