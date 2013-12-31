using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzureInfrastructure.Web.Models
{
    public class ProvisionRequest : TableEntity
    {
        public string Number { get; set; }

        public string SubmittedBy { get; set; }
        public DateTime SubmittedOn { get; set; }

        public string ApprovedBy { get; set; }
        public DateTime ApprovedOn { get; set; }
        
        public string FulfilledBy { get; set; }
        public DateTime FulfilledOn { get; set; }

        // AwaitingRequestAssignment, AwaitingEstimate, AwaitingFulfillment, FulfilledButAwaitingApproval, FulfilledAndApproved
        public ProvisionRequestStatus Status { get; set; }

        public string Request { get; set; }
        public string Estimate { get; set; }
        public IList<TraceMessage> FulfillmentTrace { get; set; }
    }
}
