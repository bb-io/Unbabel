namespace Apps.Unbabel.Models.Entities;

public class PipelineEntity
{
    public string Id { get; set; }
    
    public string? Name { get; set; }

    public string? Source_language { get; set; }
    public string? Target_language { get; set; }
    
    public PipelineGroupEntity Group { get; set; }

    public string DisplayName => Name ?? $"{Group.Name}: {Source_language} - {Target_language}";
}