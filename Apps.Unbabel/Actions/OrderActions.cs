using Apps.Unbabel.Constants;
using Apps.Unbabel.Invocables;
using Apps.Unbabel.Models.Entities;
using Apps.Unbabel.Models.Request.Order;
using Apps.Unbabel.Models.Request.Project;
using Apps.Unbabel.Models.Response.Order;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Apps.Unbabel.Actions;

[ActionList]
public class OrderActions : UnbabelInvocable
{
    public OrderActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("List orders", Description = "List all orders")]
    public async Task<ListOrdersResponse> ListOrders([ActionParameter] ProjectRequest input)
    {
        var request = new RestRequest($"/v0/customers/{CustomerId}/projects/{input.ProjectId}/orders");
        var items = await ProjectsClient.Paginate<OrderEntity>(request, Creds);

        return new(items);
    }

    [Action("Search orders", Description = "Search for orders based on the provided criterias")]
    public async Task<ListOrdersResponse> SearchOrders(
        [ActionParameter] ProjectRequest project,
        [ActionParameter] SearchOrdersRequest input)
    {
        var request = new RestRequest($"/v0/customers/{CustomerId}/projects/{project.ProjectId}/orders");
        var items = await ProjectsClient.Paginate<OrderEntity>(request, Creds,
            JObject.FromObject(input, JsonSerializer.Create(JsonConfig.Settings)));

        return new(items);
    }
}