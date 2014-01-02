using AzureInfrastructure.Web.ServiceProviders;
using AzureInfrastructure.Web.ServiceProviders.SelectionProvider;
using AzureInfrastructure.Web.Models;
using AzureInfrastructure.Web.ViewModels.VM;

using log4net;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AzureInfrastructure.Web.Filters;
using AzureInfrastructure.Web.ServiceProviders.LiveTrace;
using System.Net;

namespace AzureInfrastructure.Web.Controllers
{
    public class VMController : Controller
    {
        IVMProvider _vmProvider;
        ISelectionProvider _selectionProvider;
        ILog _log;
        ILiveTraceProvider _liveTrace;

        public VMController(IVMProvider vmProvider, ISelectionProvider selectionProvider, ILiveTraceProvider liveTrace)
        {
            _vmProvider = vmProvider;
            _selectionProvider = selectionProvider;
            _log = LogManager.GetLogger(typeof(VMController).Name);
            _liveTrace = liveTrace;
        }

        //
        // GET: /VM/
        public ActionResult CreateVM()
        {
            LoadCreateVMSelectionsInViewBag();
            return View();
        }

        // POST: /VM/
        [HttpPost]
        [Log("INFO")]
        public ActionResult CreateVM(CreateVMViewModel setting)
        {
            var message = string.Format("Started Service Request {0} for {1} VMs", setting.RequestNumber, setting.NumberOfVM);
            ViewBag.Message = message; 

            _liveTrace.SendTraceMessage(new TraceMessage(){Title=message, Type=TraceMessage.Info});

            LoadCreateVMSelectionsInViewBag();
            return View();
        }

        void LoadCreateVMSelectionsInViewBag()
        {
            ViewBag.VMTypeSelection = _selectionProvider.GetSelection<VMType>();
            ViewBag.VMSizeSelection = _selectionProvider.GetSelection<VMSize>();
        }
    }
}
