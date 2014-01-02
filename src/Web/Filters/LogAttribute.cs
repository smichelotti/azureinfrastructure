using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace AzureInfrastructure.Web.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        string _level;
        public LogAttribute(string level = "DEBUG")
        {
            _level = level;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            log(filterContext.ActionDescriptor.ControllerDescriptor.ControllerType.FullName,
                                filterContext.ActionDescriptor.ActionName,
                                "...Exiting");
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext) 
        {
            base.OnActionExecuting(filterContext);
            log(filterContext.ActionDescriptor.ControllerDescriptor.ControllerType.FullName,
                 filterContext.ActionDescriptor.ActionName,
                 "...Entering");
        }

        private void log(string controllerName, string actionName, string message)
        {
            ILog log = LogManager.GetLogger(controllerName);
            var logMessage = actionName + message;
            switch (_level)
            {
                case "DEBUG":
                    log.Debug(logMessage);
                    break;
                case "INFO":
                    log.Info(logMessage);
                    break;
                case "WARN":
                    log.Warn(logMessage);
                    break;
                case "ERROR":
                    log.Error(logMessage);
                    break;
                case "FATAL":
                    log.Fatal(logMessage);
                    break;
                default:
                    log.Debug(logMessage);
                    break;
            }
        }

    }
}
