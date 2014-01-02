using AzureInfrastructure.Web.ServiceProviders;
using AzureInfrastructure.Web.ServiceProviders.AuditProvider;
using AzureInfrastructure.Web.ViewModels.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzureInfrastructure.Web.Controllers
{
    public class AuditController : Controller
    {
        IAuditProvider _auditProvider;
        public AuditController(IAuditProvider auditProvider)
        {
            _auditProvider = auditProvider;
        }


        public ActionResult SearchAudit()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SearchAudit(string srNumber)
        {
            var auditEntries = _auditProvider.Search(srNumber);

            List<SearchViewModel> model = new List<SearchViewModel>();

            foreach (var entry in auditEntries)
            {
                model.Add(new SearchViewModel() { SRNumber = entry.Id, Content = entry.Content });
            }
            return View(model);
        }

    }
}
