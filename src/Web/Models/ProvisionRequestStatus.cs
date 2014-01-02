using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureInfrastructure.Web.Models
{
    public enum ProvisionRequestStatus
	{
        AwaitingRequestAssignment,
        AwaitingEstimate,
        AwaitingFulfillment,
        FulfilledButAwaitingApproval,
        FulfilledAndApproved	         
	} 
}