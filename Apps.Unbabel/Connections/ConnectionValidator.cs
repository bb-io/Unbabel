using Apps.Unbabel.Api;
using Apps.Unbabel.Constants;
using Apps.Unbabel.Enums;
using Apps.Unbabel.Models.Entities;
using Apps.Unbabel.Models.Response;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using RestSharp;

namespace Apps.Unbabel.Connections;

public class ConnectionValidator : IConnectionValidator
{
    public async ValueTask<ConnectionValidationResponse> ValidateConnection(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        CancellationToken cancellationToken)
    {
        var creds = authenticationCredentialsProviders.ToArray();
        var customerId = creds.Get(CredsNames.CustomerId).Value;
        var client = new UnbabelClient(ApiType.Pipelines);


        var endpoint = $"/v0/customers/{customerId}/pipelines";
        var request = new RestRequest(endpoint);

        try
        {
            await client.ExecuteWithErrorHandling<PaginationResponse<TranslationEntity>>(request, creds);

            return new()
            {
                IsValid = true
            };
        }
        catch (Exception ex)
        {
            return new()
            {
                IsValid = false,
                Message = ex.Message
            };
        }
    }
}