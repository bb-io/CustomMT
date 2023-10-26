using Blackbird.Applications.Sdk.Common;

namespace Apps.CustomMT.Models.Input
{
    public class MultipleTextInput
    {
        [Display("Texts")]
        public List<string> Texts { get; set; }
    }
}
