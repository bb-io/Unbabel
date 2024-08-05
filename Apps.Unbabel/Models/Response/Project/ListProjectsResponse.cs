using Apps.Unbabel.Models.Entities;

namespace Apps.Unbabel.Models.Response.Project;

public record ListProjectsResponse(List<ProjectEntity> Projects);