using Apps.CustomMT.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;

namespace Apps.CustomMT.Connections;

public class ConnectionDefinition : IConnectionDefinition
{
    public IEnumerable<ConnectionPropertyGroup> ConnectionPropertyGroups => new List<ConnectionPropertyGroup>
    {
        new()
        {
            Name = "Developer API key",
            AuthenticationType = ConnectionAuthenticationType.Undefined,
            ConnectionUsage = ConnectionUsage.Actions,
            ConnectionProperties = new List<ConnectionProperty>
            {
                new(CredsNames.ApiToken)
                {
                    DisplayName = "API Token",
                },
            }
        }
    };

    public IEnumerable<AuthenticationCredentialsProvider> CreateAuthorizationCredentialsProviders(
        Dictionary<string, string> values)
    {
        var token = values.First(x => x.Key == CredsNames.ApiToken);
        yield return new(AuthenticationCredentialsRequestLocation.None, token.Key, token.Value);
    }
}