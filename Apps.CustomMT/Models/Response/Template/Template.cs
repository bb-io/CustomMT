using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.CustomMT.Models.Response.Template;

public class Template
{
    [JsonProperty("template_name")]
    [Display("Template name")]
    public string TemplateName { get; set; }
}