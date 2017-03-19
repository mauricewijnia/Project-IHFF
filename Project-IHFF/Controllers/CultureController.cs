using Project_IHFF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_IHFF.Controllers
{
    public class CultureController : Controller
    {
        // GET: Culture
        public ActionResult Index()
        {
            CultureRepository repo = new CultureRepository();
            return View(repo.locaties());

        }
    }
}