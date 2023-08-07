using Apps.CustomMT.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.CustomMT.Models.Request.Translate.Base;

public class TranslateRequest
{
    [JsonProperty("template_name")]
    [Display("Template name")]
    [DataSource(typeof(TemplateDataHandler))]
    public string TemplateName { get; set; }
}