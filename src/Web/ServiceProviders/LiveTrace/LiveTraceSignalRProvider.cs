using AzureInfrastructure.Web.Models;
using AzureInfrastructure.Web.ViewModels.Trace;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace AzureInfrastructure.Web.ServiceProviders.LiveTrace
{
    public class LiveTraceSignalRProvider : ILiveTraceProvider, IDisposable
    {
        HubConnection _hubConnection;
        IHubProxy _hubProxy;

        public LiveTraceSignalRProvider(string hubUrl)
        {
            _hubConnection = new HubConnection(hubUrl);
            _hubConnection.Credentials = CredentialCache.DefaultCredentials;

           
            _hubProxy = _hubConnection.CreateHubProxy("LiveTraceSignalRHub");
            _hubConnection.Start().Wait();
        }

        public void ClearAllTrace()
        {
            _hubProxy.Invoke("ClearAllTrace");
        }


        public void SendTraceMessage(TraceMessage message)
        {
            _hubProxy.Invoke("SendTraceMessage", message);
        }

        void IDisposable.Dispose()
        {
            _hubConnection.Dispose();
        }
    }
}