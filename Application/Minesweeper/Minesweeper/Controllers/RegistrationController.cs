using Minesweeper.Models;
using Minesweeper.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minesweeper.Controllers
{
    // Controller for actions related to registering a user
    [CustomLogging] // Custom logging attribute for entry and exit to controller
    public class RegistrationController : Controller
    {
        // Action method for bringing up a registration form
        // GET: Registration
        [HttpGet]
        public ActionResult Register()
        {
            UserModel user = new UserModel();

            return View("Registration", user);
        }

        // Action method for registering 
        // POST: Registration
        [HttpPost]        
        public ActionResult Register(UserModel user)
        {
            // Validate UserModel data
            if (!ModelState.IsValid)
            {
                return View("RegistrationError", user);
            }

            // Service for registering users
            RegistrationService registrationService = new RegistrationService();

            // Register user. Returns true for success and false for failure
            bool userRegistered = registrationService.RegisterUser(user);

            // Place holder Logic for routing dependent upon registration results
            if (userRegistered)
            {
                return View("RegistrationSuccess", user);
            } 
            else
            {
                return View("RegistrationError", user);
            }

        }
    }
}