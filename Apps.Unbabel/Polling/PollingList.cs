using Apps.Unbabel.Invocables;
using Apps.Unbabel.Models.Entities;
using Apps.Unbabel.Models.Request.Project;
using Apps.Unbabel.Polling.Models;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Polling;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Unbabel.Polling;

[PollingEventList]
public class PollingList : UnbabelInvocable
{
    public PollingList(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [PollingEvent("(P) On project status changed", "This event triggers when a project changes its status")]
    public async Task<PollingEventResponse<string, ProjectEntity>> OnProjectStatusChanged(
    PollingEventRequest<string> input,
    [PollingEventParameter] ProjectRequest projectIdentifier,
    [PollingEventParameter] OptionalProjectStatus status)
    {
        var request = new RestRequest($"/v0/customers/{CustomerId}/projects/{projectIdentifier.ProjectId}");
        var project = await ProjectsClient.ExecuteWithErrorHandling<ProjectEntity>(request, Creds);

        return new()
        {
            FlyBird = status.Status == null ? (input.Memory != null && project.Status != input.Memory) : project.Status == status.Status,
            Result = project,
            Memory = project.Status,
        };
    }
}

