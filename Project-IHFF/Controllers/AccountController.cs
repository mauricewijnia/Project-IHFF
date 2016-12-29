using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_IHFF.Models;
using System.Web.Security;
using Project_IHFF.Repositories;

namespace Project_IHFF.Controllers
{
    public class AccountController : Controller
    {
        IAccountRepository accountRepository = new DbAccountRepository();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register(string error = "")
        {
            ViewBag.error = error;
            ViewBag.NewAccount = "Make a new account";
            return View();
        }

        [HttpPost]
        public ActionResult Register(string Name, string Emailadress, string Password, string Passwordcheck)
        {
            if (Password != Passwordcheck)
            {
                return RedirectToAction("Register", "Account", new { fout = "The filled in passwords do not match!" });
            }
            ViewBag.Registering = "Account has been made, log in here";
            accountRepository.CreateAccount(Name, Emailadress, Password);

            return View("login");
        }

        public ActionResult Login()
        {
            ViewBag.login = "Login";
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Emailadress, string Password)
        {
            Accounts account = accountRepository.GetAccount(Emailadress, Password);
            if (account != null)
            {
                FormsAuthentication.SetAuthCookie(account.email, false);
                Session["loggedin_account"] = account;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Login = "Login";
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}