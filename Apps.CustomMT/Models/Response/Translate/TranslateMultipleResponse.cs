using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.CustomMT.Models.Response.Translate;

public class TranslateMultipleResponse
{
    [JsonProperty("translated_text")]
    [Display("Translated text")]
    public IEnumerable<string> TranslatedText { get; set; }
}