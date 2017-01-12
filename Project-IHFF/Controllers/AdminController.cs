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
        private DateTime baseTime = new DateTime(2017, 1, 1, 0, 0, 0);

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddItem()
        {
            return View();
        }
        public ActionResult Films()
        {
            return View(repository.GetAllFilms());
        }

        public ActionResult Specials()
        {
            return View(repository.GetAllSpecials());
        }

        public ActionResult Restaurants()
        {
            return View(repository.GetAllRestaurants());
        }

        public ActionResult DeleteFilm(int id)
        {
            DeleteImageByItemId(id);
            repository.DeleExhibitionsForFilm(id);
            repository.DeleteItem(id);
            return RedirectToAction("Films");
        }

        public ActionResult DeleteSpecial(int id)
        {
            DeleteImageByItemId(id);
            repository.DeleteItem(id);
            return RedirectToAction("Specials");
        }

        public ActionResult DeleteRestaurant(int id)
        {
            DeleteImageByItemId(id);
            repository.DeleteItem(id);
            return RedirectToAction("Restaurants");
        }

        public ActionResult EditFilm(int id)
        {
            FilmsViewModel viewModel = new FilmsViewModel();
            viewModel.film = repository.GetFilmById(id);
            viewModel.exhibitions = repository.GetExhibitionForFilmID(id);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditFilm(FilmsViewModel filmViewModel, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    DeleteImageByItemId(filmViewModel.film.id);
                    upload.SaveAs(HttpContext.Server.MapPath("/img/films/") + upload.FileName);
                    filmViewModel.film.imagePath = "/img/films/" + upload.FileName;
                }

                repository.UpdateItem(filmViewModel.film);
                Items item = repository.GetFilmById(filmViewModel.film.id);
                foreach (var exhibition in filmViewModel.exhibitions)
                {
                    UpdateExhibition(exhibition);                    
                }
                return RedirectToAction("EditItem");
            }
            else
            {
                ModelState.AddModelError("Oops", "Something went wrong.");
                return View();
            }
        }


        public ActionResult AddFilm()
        {
            FilmsViewModel filmsViewModel = new FilmsViewModel();
            filmsViewModel.exhibitions.Add(new Exhibitions());
            filmsViewModel.exhibitions.Add(new Exhibitions());
            filmsViewModel.exhibitions[0].startTime = baseTime;
            filmsViewModel.exhibitions[0].endTime = baseTime;
            filmsViewModel.exhibitions[1].startTime = baseTime;
            filmsViewModel.exhibitions[1].endTime = baseTime;

            return View(filmsViewModel);
        }

        [HttpPost]
        public ActionResult AddFilm(FilmsViewModel filmViewModel, HttpPostedFileBase upload)
        {

            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    upload.SaveAs(HttpContext.Server.MapPath("/img/films/") + upload.FileName);
                    filmViewModel.film.imagePath = "/img/films/" + upload.FileName;
                }

                repository.AddItem(filmViewModel.film);
                Items item = repository.GetItemByName(filmViewModel.film.name);
                foreach (var exhibition in filmViewModel.exhibitions)
                {
                    exhibition.filmId = item.id;
                    if (exhibition.startTime != baseTime)
                    {
                        repository.AddFilmExhibition(exhibition);
                    }
                }
                ModelState.Clear();
                return View();
            }
            else
            {
                ModelState.AddModelError("Oops", "Something went wrong.");
                return View();
            }
        }

        public ActionResult EditSpecial(int id)
        {     
            return View(repository.GetItemById(id));
        }

        [HttpPost]
        public ActionResult EditSpecial(Specials special, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    DeleteImageByItemId(special.id);
                    upload.SaveAs(HttpContext.Server.MapPath("/img/specials/") + upload.FileName);
                    special.imagePath = "/img/specials/" + upload.FileName;
                }

                special.price = 0;
                repository.UpdateItem(special);

                ModelState.Clear();
                return RedirectToAction("Specials");
            }
            else
            {
                ModelState.AddModelError("Oops", "Something went wrong.");
                return View();
            }
            
        }

        public ActionResult AddSpecial()
        {
            Specials special = new Specials();
            special.startTime = baseTime;
            special.endTime = baseTime;
            return View(special);
        }

        [HttpPost]
        public ActionResult AddSpecial(Specials special, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    upload.SaveAs(HttpContext.Server.MapPath("/img/specials/") + upload.FileName);
                    special.imagePath = "/img/specials/" + upload.FileName;
                }

                special.price = 0;
                repository.AddItem(special);

                ModelState.Clear();
                return View();
            }
            else
            {
                ModelState.AddModelError("Oops", "Something went wrong.");
            }
            return View();
        }

        public ActionResult EditRestaurant(int id)
        {
            return View(repository.GetItemById(id));
        }

        [HttpPost]
        public ActionResult EditRestaurant(Restaurants restaurant, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    DeleteImageByItemId(restaurant.id);
                    upload.SaveAs(HttpContext.Server.MapPath("/img/Restaurants/") + upload.FileName);
                    restaurant.imagePath = "/img/Restaurants/" + upload.FileName;
                }
                repository.UpdateItem(restaurant);
                ModelState.Clear();
                return RedirectToAction("Restaurants");
            }
            else
            {
                ModelState.AddModelError("Oops", "Something went wrong.");
            }
            return View();
        }

        public ActionResult AddRestaurant()
        {
            Restaurants restaurant = new Restaurants();
            return View(restaurant);
        }

        [HttpPost]
        public ActionResult AddRestaurant(Restaurants restaurant, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    upload.SaveAs(HttpContext.Server.MapPath("/img/Restaurants/") + upload.FileName);
                    restaurant.imagePath = "/img/Restaurants/" + upload.FileName;
                }
                repository.AddItem(restaurant);
                ModelState.Clear();
                return View();
            }
            else
            {
                ModelState.AddModelError("Oops", "Something went wrong.");
            }
            return View();
        }

        public void UpdateExhibition(Exhibitions exhibition)
        {
            if(exhibition.startTime != baseTime)
            {
                if(exhibition.id == 0)
                {
                    repository.AddFilmExhibition(exhibition);
                }

                else
                {
                    repository.UpdateExhibition(exhibition);
                }
            }
            else if(exhibition.id != 0)
            {
                repository.DeleteExhibition(exhibition);
            }
            
        }

        public void DeleteImageByItemId(int id)
        {
            string imagePath = repository.GetItemById(id).imagePath;
            if (imagePath != null)
            {
                string oldImagePath = Request.MapPath(imagePath);
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }
        }
    }
}