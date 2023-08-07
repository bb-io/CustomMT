using Apps.CustomMT.Actions;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.CustomMT.DataSourceHandlers;

public class TemplateDataHandler : BaseInvocable, IAsyncDataSourceHandler
{
    public TemplateDataHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(
        DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var actions = new TranslateActions();
        var templates = await actions.GetAllTemplates(InvocationContext.AuthenticationCredentialsProviders);

        return templates.Templates
            .Where(x => context.SearchString is null ||
                        x.TemplateName.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(x => x.TemplateName, x => x.TemplateName);
    }
}