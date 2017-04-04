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
        public ActionResult Register()
        {
            ViewBag.newAccount = "Create a new account.";
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel register_account)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("register-error", "Something went wrong.");
                return View();
            }

            Accounts account = new Accounts(register_account.firstName, register_account.lastName, register_account.phoneNumber, register_account.email, register_account.Password);
            accountRepository.CreateAccount(account);

            return RedirectToAction("Login", "Account");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel login_account)
        {
            if (ModelState.IsValid)
            {
                Accounts account = accountRepository.GetAccount(login_account.email);
                if (account != null && account.password == login_account.password)
                {
                    FormsAuthentication.SetAuthCookie(account.email, false);

                    Session["loggedin_account"] = account;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("login-error", "The email address or password provided is incorrect.");
                }
            }
            return View(login_account);
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}