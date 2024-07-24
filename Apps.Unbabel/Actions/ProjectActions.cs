using Apps.Unbabel.Constants;
using Apps.Unbabel.Invocables;
using Apps.Unbabel.Models.Entities;
using Apps.Unbabel.Models.Request.Project;
using Apps.Unbabel.Models.Response.Project;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Apps.Unbabel.Actions;

[ActionList]
public class ProjectActions : UnbabelInvocable
{
    public ProjectActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("List projects", Description = "List all projects")]
    public async Task<ListProjectsResponse> ListProjects()
    {
        var request = new RestRequest($"/v0/customers/{CustomerId}/projects");
        var items = await ProjectsClient.Paginate<ProjectEntity>(request, Creds);

        return new(items);
    }

    [Action("Search projects", Description = "Search for projects based on the provided criterias")]
    public async Task<ListProjectsResponse> SearchProjects([ActionParameter] SearchProjectsRequest input)
    {
        var request = new RestRequest($"/v0/customers/{CustomerId}/projects:search", Method.Post);
        var items = await ProjectsClient.Paginate<ProjectEntity>(request, Creds,
            JObject.FromObject(input, JsonSerializer.Create(JsonConfig.Settings)));

        return new(items);
    }

    [Action("Get project", Description = "Get details of a specific project")]
    public Task<ProjectEntity> GetProject([ActionParameter] ProjectRequest input)
    {
        var request = new RestRequest($"/v0/customers/{CustomerId}/projects/{input.ProjectId}");
        return ProjectsClient.ExecuteWithErrorHandling<ProjectEntity>(request, Creds);
    }

    [Action("Create project", Description = "Create a new project")]
    public Task<ProjectEntity> CreateProject([ActionParameter] CreateProjectRequest input)
    {
        var request = new RestRequest($"/v0/customers/{CustomerId}/projects", Method.Post)
            .WithJsonBody(input, JsonConfig.Settings);

        return ProjectsClient.ExecuteWithErrorHandling<ProjectEntity>(request, Creds);
    }

    [Action("Cancel project", Description = "Cancel a specific project")]
    public Task CancelProject([ActionParameter] ProjectRequest input)
    {
        var request = new RestRequest($"/v0/customers/{CustomerId}/projects/{input.ProjectId}", Method.Delete);
        return ProjectsClient.ExecuteWithErrorHandling(request, Creds);
    }

    [Action("Submit project", Description = "Submits a project to be actioned")]
    public Task SubmitProject([ActionParameter] ProjectRequest input)
    {
        var request = new RestRequest($"/v0/customers/{CustomerId}/projects/{input.ProjectId}:submit",
            Method.Post);
        return ProjectsClient.ExecuteWithErrorHandling(request, Creds);
    }
}