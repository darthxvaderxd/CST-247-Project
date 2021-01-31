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

            // Check if user logged in already
            if (Session["login"] != null)
            {
                user = (LoginModel) Session["login"];
                return View("LoginSuccess", user);
            }

            return View("Login", user);
        }

        // Action method for logging out a user
        // Get: Logout
        [HttpGet]
        public ActionResult Logout()
        {
            // Clear Session
            if (Session["login"] != null)
            {
                Session.Clear();
            }

            return Redirect("Login");
        }

        // Action method for verifying a username and password
        // Post: Login
        [HttpPost]
        public ActionResult Login(LoginModel user)
        {
            // Data verification for user model
            if (!ModelState.IsValid)
            {
                return View("Login", user);
            }

            // Business service for user authentication
            SecurityService securityService = new SecurityService();

            // Search for User in database. Returns true for success false for fail.
            bool userValid = securityService.Authenticate(user);

            // Placer holder Logic for routing dependent upon query results
            if (userValid)
            {
                Session["login"] = user;
                return View("LoginSuccess", user);
            }
            else
            {
                Session.Clear();
                return View("LoginError", user);
            }

        }
    }
}