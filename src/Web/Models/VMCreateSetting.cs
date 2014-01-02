using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzureInfrastructure.Web.Models
{
    public class VMCreateSetting
    {
        public string SRNumber { get; set; }
        public int VMType { get; set; }
        public int VMSize { get; set; }
        public int NumberOfVM { get; set; }
    }
}
