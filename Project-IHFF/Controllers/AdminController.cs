using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_IHFF.Models;
using Project_IHFF.Repositories;
using System.IO;

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
            filmsViewModel.exhibitions.Add(new ExhibitionsSet());
            filmsViewModel.exhibitions.Add(new ExhibitionsSet());
            filmsViewModel.exhibitions[0].startTime = new DateTime(2017, 1, 1, 0, 0, 0);
            filmsViewModel.exhibitions[0].endTime = new DateTime(2017, 1, 1, 0, 0, 0);
            filmsViewModel.exhibitions[1].startTime = new DateTime(2017, 1, 1, 0, 0, 0);
            filmsViewModel.exhibitions[1].endTime = new DateTime(2017, 1, 1, 0, 0, 0);

            return PartialView(filmsViewModel);
        }

        [HttpPost]
        public ActionResult _AddFilm(FilmsViewModel filmViewModel)
        {
            if (filmViewModel.exhibitions[0].startTime != new DateTime(2017, 1, 1, 0, 0, 0))
            {
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
            }
            else
            {
                // throw error
            }
            
            

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