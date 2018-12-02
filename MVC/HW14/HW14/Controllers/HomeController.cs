using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW14.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Library()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "There you can help me add new books or interesting links to my library.";

            return View();
        }
    }
}