using Apps.Unbabel.Models.Entities;

namespace Apps.Unbabel.Models.Response.File;

public class UploadFileResponse : FileEntity
{
    public string UploadUrl { get; set; }
}