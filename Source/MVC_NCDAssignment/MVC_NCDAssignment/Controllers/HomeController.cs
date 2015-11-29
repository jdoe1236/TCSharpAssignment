using MVC_NCDAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_NCDAssignment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
                return RedirectToAction("Search", "Account");

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

     
    }
}
