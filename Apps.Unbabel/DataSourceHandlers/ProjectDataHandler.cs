using Apps.Unbabel.Constants;
using Apps.Unbabel.Invocables;
using Apps.Unbabel.Models.Entities;
using Apps.Unbabel.Models.Request.Project;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Apps.Unbabel.DataSourceHandlers;

public class ProjectDataHandler : UnbabelInvocable, IAsyncDataSourceHandler
{
    public ProjectDataHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var request = new RestRequest($"/v0/customers/{CustomerId}/projects:search", Method.Post);
        var items = await ProjectsClient.Paginate<ProjectEntity>(request, Creds,
            JObject.FromObject(new SearchProjectsRequest()
            {
                Name = context.SearchString
            }, JsonSerializer.Create(JsonConfig.Settings)), 50);

        return items.DistinctBy(x => x.Id).ToDictionary(x => x.Id, x => x.Name);
    }
}