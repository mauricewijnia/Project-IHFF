using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_IHFF.Controllers
{
    public class ErrorController : Controller
    {
        //Toon foutmelding
        public ActionResult Index(string errorMessage)
        {
            ViewBag.Error = errorMessage;
            return View();
        }
    }
}