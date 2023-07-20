using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.CustomMT.Models.Request.Translate.Base;

public class TranslateRequest
{
    [JsonProperty("template_name")]
    [Display("Template name")]
    public string TemplateName { get; set; }
}