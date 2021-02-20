using Minesweeper.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace Minesweeper.Controllers
{
    // Attribute that can be applied for logging entry and exit from controllers.
    public class CustomLoggingAttribute : FilterAttribute, IActionFilter
    {
        // Dependency injection using Unity providing an instance of ILogger
        [Dependency]
        public ILogger Logger { get; set; }

        // Log exit from controller and method
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string controllerName = (string)filterContext.RouteData.Values["Controller"];
            string actionName = (string)filterContext.RouteData.Values["Action"];

            Logger.Info("Exiting " + controllerName + "Controller." + actionName + "()");
        }

        // Log entry into controller and method
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controllerName = (string)filterContext.RouteData.Values["Controller"];
            string actionName = (string)filterContext.RouteData.Values["Action"];

            Logger.Info("Entering " + controllerName + "Controller." + actionName + "()");
        }
    }
}