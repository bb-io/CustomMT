using Apps.CustomMT.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.CustomMT.Models.Identifiers
{
    public class TemplateIdentifier
    {
        [Display("Template")]
        [DataSource(typeof(TemplateDataHandler))]
        public string Template { get; set; }
    }
}
