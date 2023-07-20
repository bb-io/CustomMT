using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.CustomMT.Models.Response.Template;

public class FullTemplate : Template
{
    [JsonProperty("source_language")]
    [Display("Source language")]
    public string SourceLanguage { get; set; }
    
    [JsonProperty("target_language")]
    [Display("Target language")]
    public string TargetLanguage { get; set; }
}