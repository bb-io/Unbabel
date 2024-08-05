using Apps.Unbabel.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;

namespace Apps.Unbabel.Connections;

public class ConnectionDefinition : IConnectionDefinition
{
    public IEnumerable<ConnectionPropertyGroup> ConnectionPropertyGroups => new List<ConnectionPropertyGroup>
    {
        new()
        {
            Name = "Basic",
            AuthenticationType = ConnectionAuthenticationType.Undefined,
            ConnectionUsage = ConnectionUsage.Actions,
            ConnectionProperties = new List<ConnectionProperty>
            {
                new(CredsNames.CustomerId) { DisplayName = "Customer ID" },
                new(CredsNames.UserName) { DisplayName = "Username" },
                new(CredsNames.Password) { DisplayName = "Password", Sensitive = true },
            }
        }
    };

    public IEnumerable<AuthenticationCredentialsProvider> CreateAuthorizationCredentialsProviders(
        Dictionary<string, string> values)
    {
        yield return new(
            AuthenticationCredentialsRequestLocation.Body,
            CredsNames.UserName,
            values[CredsNames.UserName]);       
        
        yield return new(
            AuthenticationCredentialsRequestLocation.Body,
            CredsNames.Password,
            values[CredsNames.Password]);
        
        yield return new(
            AuthenticationCredentialsRequestLocation.Body,
            CredsNames.CustomerId,
            values[CredsNames.CustomerId]);
    }
}