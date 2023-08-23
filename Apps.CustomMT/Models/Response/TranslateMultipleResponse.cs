using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.CustomMT.Models.Response;

public class TranslateMultipleResponse
{
    [JsonProperty("translated_text")]
    [Display("Translations")]
    public IEnumerable<string> TranslatedText { get; set; }
}