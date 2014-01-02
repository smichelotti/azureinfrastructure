using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using AzureInfrastructure.Web.ViewModels.Trace;
using AzureInfrastructure.Web.Models;

namespace AzureInfrastructure.Web.ServiceProviders.LiveTrace
{
    public class LiveTraceSignalRHub : Hub
    {
        public void SendTraceMessage(TraceMessage message)
        {
            Clients.All.ReceiveTraceMesssage(new TraceMessageViewModel() { Type = message.Type.ToString(), Title = message.Title });
        }

        public void ClearAllTrace()
        {
            Clients.All.ClearAllTrace();
        }
    }
}