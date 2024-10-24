namespace Apps.Unbabel.Models.Request.File;

public class UploadFileRequest
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Extension { get; set; }
    
    public UploadFileRequest(UploadFileInput input, FileContentRequest file)
    {
        Name = file.File.Name;
        Description = input.Description ?? "No description";
        Extension = Path.GetExtension(file.File.Name).Replace(".", string.Empty);
    }
}