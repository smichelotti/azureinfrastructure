using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AzureInfrastructure.Web.App_Start.SignalRStartup))]

namespace AzureInfrastructure.Web.App_Start
{
    public class SignalRStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}