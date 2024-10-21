using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Unbabel.Models.Entities;

public class FileEntity
{
    [Display("ID")]
    public string Id { get; set; }

    [Display("Project ID")]
    public string ProjectId { get; set; }

    [Display("File name")]
    public string Name { get; set; }

    [Display("Description")]
    public string Description { get; set; }

    [Display("Extension")]
    public string Extension { get; set; }

    [Display("Created at")]
    public DateTime CreatedAt { get; set; }

    [Display("Download URL")]
    [JsonProperty("download_url")]
    public string? DownloadUrl { get; set; }
}