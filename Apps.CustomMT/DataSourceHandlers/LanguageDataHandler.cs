using Apps.CustomMT.Constants;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.CustomMT.DataSourceHandlers;

public class LanguageDataHandler : IDataSourceHandler
{
    public Dictionary<string, string> GetData(DataSourceContext context)
    {
        return Languages.AvailableLanguages.Where(x => context.SearchString is null ||
                                                       x.Value.Contains(context.SearchString,
                                                           StringComparison.OrdinalIgnoreCase))
            .ToDictionary(x => x.Key, x => x.Value);
    }
}