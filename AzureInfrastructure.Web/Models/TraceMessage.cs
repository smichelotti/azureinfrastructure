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
        public const string SuccessType = "SUCCESS";
        public const string InfoType = "INFO";
        public const string WarningType = "WARNING";
        public const string ErrorType = "ERROR";
    }
}
