using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzureInfrastructure.Web.Models
{
    public class AuditEntry : TableEntity
    {
        public string Id { get; set; }
        public string Content { get; set; }        
    }
}
