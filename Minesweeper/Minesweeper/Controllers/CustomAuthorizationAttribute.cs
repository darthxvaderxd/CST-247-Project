using Minesweeper.Models;
using Minesweeper.Services.Business;
using System;
using System.Web.Mvc;

namespace Minesweeper.Controllers
{
    // Class that provides authorization filter to check for logged in user
    internal class CustomAuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            // Security service
            SecurityService securityService = new SecurityService();

            // Check for logged in user information in session
            LoginModel loginModel = (LoginModel)filterContext.HttpContext.Session["login"];

            bool success = false;

            // If user data present, verify user and set success to true
            if (loginModel != null)
            {
                success = securityService.Authenticate(loginModel);
            }

            // If success true allow access, otherwise reroute to login
            if (success)
            {

            }
            else
            {
                filterContext.Result = new RedirectResult("/Login");
            }
        }
    }
}