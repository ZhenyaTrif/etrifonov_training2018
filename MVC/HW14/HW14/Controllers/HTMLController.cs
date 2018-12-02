using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW14.Controllers
{
    public class HTMLController : Controller
    {
        // GET: HTML
        public ActionResult HTML()
        {
            return View();
        }

        public FileResult Download(string filePath, string fileName)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}