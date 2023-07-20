using Apps.CustomMT.Models.Request.Translate.Base;

namespace Apps.CustomMT.Models.Request.Translate;

public class TranslateSingleRequest : TranslateRequest
{
    public string Text { get; set; }
}