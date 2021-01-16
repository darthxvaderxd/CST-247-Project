using Minesweeper.Models;
using Minesweeper.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minesweeper.Controllers
{
    // Controller for actions related to logging a user into application
    public class LoginController : Controller
    {
        // Action method for brining up a login screen
        // Get: Login
        [HttpGet]
        public ActionResult Login()
        {
            LoginModel user = new LoginModel();

            return View("Login", user);
        }

        // Action method for verifying a username and password
        // Post: Login
        [HttpPost]
        public ActionResult Login(LoginModel user)
        {
            // Business service for user authentication
            SecurityService securityService = new SecurityService();

            // Data verification for user model
            if (!ModelState.IsValid)
            {
                return View("Login", user);
            }

            // Insert User into database. Returns true for success false for fail.
            bool userValid = securityService.Authenticate(user);

            // Placer holder Logic for routing dependent upon query results
            if (userValid)
            {
                return View("LoginSuccess", user);
            }
            else
            {
                return View("LoginError", user);
            }

        }
    }
}