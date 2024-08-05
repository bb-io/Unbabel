using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Unbabel.Models.Request.File;

public class FileContentRequest
{
    public FileReference File { get; set; }
    
    [Display("File name")]
    public string? FileName { get; set; }
}