using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureInfrastructure.Web.ViewModels.VM
{
    public class CreateVMViewModel
    {
        public string SRNumber { get; set; }
        public int VMType { get; set; }
        public int VMSize { get; set; }
        public int NumberOfVM { get; set; }

    }
}