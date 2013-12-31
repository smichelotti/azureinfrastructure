using AzureInfrastructure.Web.ServiceProviders;
using AzureInfrastructure.Web.ServiceProviders.ProvisionRequestProvider;
using AzureInfrastructure.Web.ViewModels.ProvisionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzureInfrastructure.Web.Controllers
{
    public class ProvisionRequestController : Controller
    {
        IProvisionRequestProvider _provisionRequestProvider;
        public ProvisionRequestController(IProvisionRequestProvider provisionRequestProvider)
        {
            _provisionRequestProvider = provisionRequestProvider;
        }


        public ActionResult SearchProvisionRequest()
        {            
            return View();
        }


        [HttpPost]
        public ActionResult SearchProvisionRequest(string requestNumber)
        {
            var auditEntries = _provisionRequestProvider.Search(requestNumber);

            List<SearchProvisionRequestViewModel> model = new List<SearchProvisionRequestViewModel>();

            foreach (var entry in auditEntries)
            {
                model.Add(new SearchProvisionRequestViewModel() {  RequestNumber = entry.Number});
            }
            return View(model);
        }

    }
}
