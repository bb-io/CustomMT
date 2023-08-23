using Blackbird.Applications.Sdk.Common;

namespace Apps.CustomMT.Models.Response;

public class TranslateSingleResponse
{
    [Display("Translation")]
    public string TranslatedText { get; set; }
}