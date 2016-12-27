using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_IHFF.Models;

namespace Project_IHFF.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registreer()
        {
            Accounts account = new Accounts();
           
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Login()
        {
            Accounts account = new Accounts();
            Session["account"] = account;
            return RedirectToAction("Index", "Home");
        }
    }
}