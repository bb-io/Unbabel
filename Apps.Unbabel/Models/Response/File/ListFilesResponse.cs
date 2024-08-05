using Apps.Unbabel.Models.Entities;

namespace Apps.Unbabel.Models.Response.File;

public record ListFilesResponse(List<FileEntity> Files);