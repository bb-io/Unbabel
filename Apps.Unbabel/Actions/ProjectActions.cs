using Apps.Unbabel.Constants;
using Apps.Unbabel.Enums;
using Apps.Unbabel.Extensions;
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

    [Action("(P) Search projects", Description = "Search for projects based on the provided criterias")]
    public async Task<ListProjectsResponse> SearchProjects([ActionParameter] SearchProjectsRequest input)
    {
        var request = new RestRequest($"/v0/customers/{CustomerId}/projects:search", Method.Post);
        var items = await ProjectsClient.Paginate<ProjectEntity>(request, Creds,
            JObject.FromObject(input, JsonSerializer.Create(JsonConfig.Settings)));

        return new(items);
    }

    [Action("(P) Get project", Description = "Get details of a specific project")]
    public Task<ProjectEntity> GetProject([ActionParameter] ProjectRequest input)
    {
        var request = new RestRequest($"/v0/customers/{CustomerId}/projects/{input.ProjectId}");
        return ProjectsClient.ExecuteWithErrorHandling<ProjectEntity>(request, Creds);
    }

    [Action("(P) Search project completed files", Description = "Search for all the files that are completed in a project. Loop over the files and download the output files.")]
    public async Task<ProjectFilesResponse> SearchProjectCompletedFiles([ActionParameter] ProjectRequest input)
    {
        var ordersRequest = new RestRequest($"/v0/customers/{CustomerId}/projects/{input.ProjectId}/orders");
        var orders = await ProjectsClient.Paginate<OrderEntity>(ordersRequest, Creds);

        var completedFiles = new List<CompletedFile>();

        foreach (var order in orders)
        {
            var jobsRequest = new RestRequest($"/v0/customers/{CustomerId}/projects/{input.ProjectId}/orders/{order.Id}/jobs");
            var jobs = await ProjectsClient.Paginate<JobEntity>(jobsRequest, Creds);
            foreach (var job in jobs)
            {
                if (job.OutputFileIds != null)
                {
                    foreach(var outputFileId in job.OutputFileIds)
                    {
                        completedFiles.Add(new CompletedFile
                        {
                            OrderId = order.Id,
                            JobId = job.Id,
                            PipelineId = job.PipelineId,
                            InputFileId = order.InputFileId,
                            OutputFileID = outputFileId,
                        });
                    }                    
                }
            }
        }

        return new ProjectFilesResponse { Files = completedFiles };
    }

    [Action("(P) Create project", Description = "Create a new project")]
    public Task<ProjectEntity> CreateProject([ActionParameter] CreateProjectRequest input)
    {
        var request = new RestRequest($"/v0/customers/{CustomerId}/projects", Method.Post)
            .WithJsonBody(input, JsonConfig.Settings);

        return ProjectsClient.ExecuteWithErrorHandling<ProjectEntity>(request, Creds);
    }

    [Action("(P) Cancel project", Description = "Cancel a specific project")]
    public Task CancelProject([ActionParameter] ProjectRequest input)
    {
        var request = new RestRequest($"/v0/customers/{CustomerId}/projects/{input.ProjectId}", Method.Delete);
        return ProjectsClient.ExecuteWithErrorHandling(request, Creds);
    }

    [Action("(P) Submit project", Description = "Submits a project to be actioned")]
    public Task SubmitProject([ActionParameter] ProjectRequest input)
    {
        var request = new RestRequest($"/v0/customers/{CustomerId}/projects/{input.ProjectId}:submit",
            Method.Post);
        return ProjectsClient.ExecuteWithErrorHandling(request, Creds);
    }
}