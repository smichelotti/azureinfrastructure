using System.Web;
using System.Web.Mvc;
using AzureInfrastructure.Web.App_Start;
using AzureInfrastructure.Web.Filters;

namespace AzureInfrastructure.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogAttribute());
        }
    }
}