using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minesweeper.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [CustomAuthorization] // Authorization filter for logged in users
        public ActionResult Index()
        {
            return View();
        }
    }
}