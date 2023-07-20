using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.CustomMT.Models.Request.Template;

public class GetTemplatesRequest
{
    [JsonProperty("source_language")]
    [Display("Source language")]
    public string SourceLanguage { get; set; }
    
    [JsonProperty("target_language")]
    [Display("Target language")]
    public string TargetLanguage { get; set; }
}