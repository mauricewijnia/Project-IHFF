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


        public ActionResult _AddSpecial()
        {
            Specials special = new Specials();
            return PartialView(special);
        }

        [HttpPost]
        public ActionResult _AddSpecial(Specials special)
        {
            special.price = 0;
            repository.AddItem(special);
            return View();
        }

        public ActionResult _AddRestaurant()
        {
            Restaurants restaurant = new Restaurants();
            return PartialView(restaurant);
        }

        [HttpPost]
        public ActionResult _AddRestaurant(Restaurants restaurant)
        {
            repository.AddItem(restaurant);
            return View();
        }
    }
}