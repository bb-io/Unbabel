using Apps.Unbabel.Constants;
using Apps.Unbabel.Enums;
using Apps.Unbabel.Models.Response;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.Unbabel.Extensions;

public static class CredsExtensions
{
    public static async Task<CredentialsResponse> GetAccessToken(
        this IEnumerable<AuthenticationCredentialsProvider> creds, ApiType apiType)
    {
        var client = new RestClient();

        var formPayload = new Dictionary<string, string>()
        {
            ["grant_type"] = "password",
            ["username"] = creds.Get(CredsNames.UserName).Value,
            ["password"] = creds.Get(CredsNames.Password).Value,
            ["client_id"] = apiType switch
            {
                ApiType.Translations => "translation-api-os",
                ApiType.Projects => "project-api",
                ApiType.Pipelines => "project-api",
                _ => throw new ArgumentOutOfRangeException(nameof(apiType), apiType, null)
            },
        };
        var request = new RestRequest(Urls.Token, Method.Post);
        formPayload.ToList().ForEach(x => request.AddParameter(x.Key, x.Value));

        var response = await client.ExecuteAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            var error = JsonConvert.DeserializeObject<ErrorResponse>(response.Content!, JsonConfig.Settings)!;
            throw new(error.ErrorDescription);
        }
        
        return JsonConvert.DeserializeObject<CredentialsResponse>(response.Content!, JsonConfig.Settings)!;
    }
}