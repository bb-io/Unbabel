namespace Apps.Unbabel.Models.Response;

public class PaginationResponse<T>
{
    public string? NextPageToken { get; set; }
    
    public IEnumerable<T> Results { get; set; }
}