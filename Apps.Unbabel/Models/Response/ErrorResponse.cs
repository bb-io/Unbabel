namespace Apps.Unbabel.Models.Response;

public class ErrorResponse
{
    public string? Detail { get; set; }
    
    public string? Message { get; set; }
    
    public string? ErrorDescription { get; set; }
}