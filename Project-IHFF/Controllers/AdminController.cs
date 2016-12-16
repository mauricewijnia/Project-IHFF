using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_IHFF.Models;
using Project_IHFF.Repositories;

namespace Project_IHFF.Controllers
{
    public class AdminController : Controller
    {
        private IItemsRepository repository = new DbItemsRepository();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddItem()
        {
            return View();
        }


        public ActionResult _AddFilm()
        {
            Films film = new Films();
            return PartialView(film);
        }

        [HttpPost]
        public ActionResult _AddFilm(Films film)
        {
            repository.AddItem(film);
            return View();
        }
    }
}