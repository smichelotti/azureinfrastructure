using AzureInfrastructure.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzureInfrastructure.Web.ServiceProviders
{
    public interface ILiveTraceProvider
    {
        void SendTraceMessage(TraceMessage message);
        void ClearAllTrace();
    }
}
