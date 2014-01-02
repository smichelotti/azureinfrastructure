using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzureInfrastructure.Web.Models
{
    public class TraceMessage
    {
        public string Type { get; set; }
        public string Title { get; set; }

        public const string Debug = "DEBUG";
        public const string Info = "INFO";
        public const string Warning = "WARNING";
        public const string Success = "SUCCESS";
        public const string Error = "ERROR";

    }
}
