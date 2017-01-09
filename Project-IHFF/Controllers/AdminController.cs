using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_IHFF.Models;
using Project_IHFF.Repositories;
using System.IO;
using System.Web.Helpers;

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
            FilmsViewModel filmsViewModel = new FilmsViewModel();
            filmsViewModel.exhibitions.Add(new Exhibitions());
            filmsViewModel.exhibitions.Add(new Exhibitions());
            filmsViewModel.exhibitions[0].startTime = new DateTime(2017, 1, 1, 0, 0, 0);
            filmsViewModel.exhibitions[0].endTime = new DateTime(2017, 1, 1, 0, 0, 0);
            filmsViewModel.exhibitions[1].startTime = new DateTime(2017, 1, 1, 0, 0, 0);
            filmsViewModel.exhibitions[1].endTime = new DateTime(2017, 1, 1, 0, 0, 0);

            return PartialView(filmsViewModel);
        }

        [HttpPost]
        public ActionResult _AddFilm(FilmsViewModel filmViewModel, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                
                if(upload != null && upload.ContentLength > 0)
                {
                    upload.SaveAs(HttpContext.Server.MapPath("/img/films/") + upload.FileName);
                    filmViewModel.film.imagePath = "/img/films/" + upload.FileName;
                }

                repository.AddItem(filmViewModel.film);
                Items item = repository.GetItemByName(filmViewModel.film.name);
                foreach (var exhibition in filmViewModel.exhibitions)
                {
                    exhibition.filmId = item.id;
                    if (exhibition.startTime != new DateTime(2017, 1, 1, 0, 0, 0))
                    {
                        repository.AddFilmExhibition(exhibition);
                    }
                }                
                ModelState.Clear();
                return RedirectToAction("AddItem");
            }
            else
            {
                ModelState.AddModelError("Oops" ,"Something went wrong.");
            }

            return View();
        }


        public ActionResult _AddSpecial()
        {
            Specials special = new Specials();
            return PartialView(special);
        }

        [HttpPost]
        public ActionResult _AddSpecial(Specials special, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    upload.SaveAs(HttpContext.Server.MapPath("/img/films/") + upload.FileName);
                    special.imagePath = "/img/films/" + upload.FileName;
                }

                special.price = 0;
                repository.AddItem(special);

                ModelState.Clear();
                return RedirectToAction("AddItem");
            }
            else
            {
                ModelState.AddModelError("Oops", "Something went wrong.");
            }
            return View();
        }

        public ActionResult _AddRestaurant()
        {
            Restaurants restaurant = new Restaurants();
            return PartialView(restaurant);
        }

        [HttpPost]
        public ActionResult _AddRestaurant(Restaurants restaurant, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    upload.SaveAs(HttpContext.Server.MapPath("/img/films/") + upload.FileName);
                    restaurant.imagePath = "/img/films/" + upload.FileName;
                }
                repository.AddItem(restaurant);
                ModelState.Clear();
                return RedirectToAction("AddItem");
            }
            else
            {
                ModelState.AddModelError("Oops", "Something went wrong.");
            }          
            return View();
        }

        
    }
}