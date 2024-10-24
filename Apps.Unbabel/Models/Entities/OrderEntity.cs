using Blackbird.Applications.Sdk.Common;

namespace Apps.Unbabel.Models.Entities;

public class OrderEntity
{
    [Display("Order ID")]
    public string Id { get; set; }

    [Display("Name")]
    public string Name { get; set; }

    [Display("Status")]
    public string Status { get; set; }

    [Display("Project ID")]
    public string ProjectId { get; set; }

    [Display("Input file ID")]
    public string InputFileId { get; set; }

    [Display("Extension")]
    public string Extension { get; set; }

    [Display("Created at")]
    public DateTime CreatedAt { get; set; }

    [Display("Completed at")]
    public DateTime? CompletedAt { get; set; }
}