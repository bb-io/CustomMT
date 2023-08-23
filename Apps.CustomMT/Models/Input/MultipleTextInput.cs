using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.CustomMT.Models.Input
{
    public class MultipleTextInput
    {
        [Display("Texts")]
        public List<string> Texts { get; set; }
    }
}
