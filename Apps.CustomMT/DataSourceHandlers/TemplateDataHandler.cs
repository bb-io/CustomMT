using Apps.CustomMT.Constants;
using Apps.CustomMT.Models;
using Apps.CustomMT.RestSharp;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.CustomMT.DataSourceHandlers;

public class TemplateDataHandler : BaseInvocable, IAsyncDataSourceHandler
{
    private readonly CustomMtClient Client;
    private IEnumerable<AuthenticationCredentialsProvider> Creds =>
        InvocationContext.AuthenticationCredentialsProviders;

    public TemplateDataHandler(InvocationContext invocationContext) : base(invocationContext)
    {
        Client = new();
    }

    public async Task<Dictionary<string, string>> GetDataAsync(
        DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var request = new CustomMtRequest(ApiEndpoints.GetTemplatesList, Method.Get, Creds);
        var response = await Client.ExecuteWithHandling<List<Template>>(request);

        return response
            .Where(x => context.SearchString is null ||
                        x.TemplateName.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(x => x.TemplateName, x => x.TemplateName);
    }
}