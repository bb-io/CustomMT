using Blackbird.Applications.Sdk.Common;

namespace Apps.CustomMT.Models.Response.Translate;

public class TranslateSingleResponse
{
    [Display("Translated text")]
    public string TranslatedText { get; set; }
}