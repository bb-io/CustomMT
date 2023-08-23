using Apps.CustomMT.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.CustomMT.Models.Identifiers
{
    public class TemplateIdentifier
    {
        [Display("Template")]
        [DataSource(typeof(TemplateDataHandler))]
        public string Template { get; set; }
    }
}
