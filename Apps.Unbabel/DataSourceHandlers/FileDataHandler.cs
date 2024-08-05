using Apps.Unbabel.Invocables;
using Apps.Unbabel.Models.Entities;
using Apps.Unbabel.Models.Request.File;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Unbabel.DataSourceHandlers;

public class FileDataHandler : UnbabelInvocable, IAsyncDataSourceHandler
{
    private FileRequest FileRequest { get; }

    public FileDataHandler(InvocationContext invocationContext, [ActionParameter] FileRequest fileRequest) : base(
        invocationContext)
    {
        FileRequest = fileRequest;
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(FileRequest.ProjectId))
            throw new("You must input Project first");

        var request =
            new RestRequest($"/v0/customers/{CustomerId}/projects/{FileRequest.ProjectId}/files");
        var items = await ProjectsClient.Paginate<FileEntity>(request, Creds);

        return items
            .Where(x => context.SearchString is null ||
                        x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(x => x.Id, x => x.Name);
    }
}