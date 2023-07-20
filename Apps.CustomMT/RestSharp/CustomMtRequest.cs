using Apps.CustomMT.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.CustomMT.RestSharp;

public class CustomMtRequest : RestRequest
{
    public CustomMtRequest(string url, Method method, IEnumerable<AuthenticationCredentialsProvider> creds) : base(url,
        method)
    {
        var token = creds.First(x => x.KeyName == CredsNames.ApiToken);
        this.AddHeader(token.KeyName, token.Value);
    }
}