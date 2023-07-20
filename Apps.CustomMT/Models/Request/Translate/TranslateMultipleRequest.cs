using Apps.CustomMT.Models.Request.Translate.Base;
using Newtonsoft.Json;

namespace Apps.CustomMT.Models.Request.Translate;

public class TranslateMultipleRequest : TranslateRequest
{
    [JsonProperty("text")]
    public IEnumerable<string> Text { get; set; }

    public TranslateMultipleRequest()
    {
    }

    public TranslateMultipleRequest(TranslateSingleRequest request)
    {
        Text = new[] { request.Text };
        TemplateName = request.TemplateName;
    }
}