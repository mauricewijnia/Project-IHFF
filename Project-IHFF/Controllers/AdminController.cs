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
    [Authorize(Users = "admin")]
    public class AdminController : Controller
    {
        private IItemsRepository repository = new DbItemsRepository();
        private DateTime baseTime = new DateTime(2017, 1, 1, 0, 0, 0);

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        
        //Link naar admin filmoverzicht
        public ActionResult Films()
        {
            return View(repository.GetAllFilms().OrderBy(x => x.name));
        }

        //Link naar admin specialoverzicht
        public ActionResult Specials()
        {
            return View(repository.GetAllSpecials().OrderBy(x => x.name));
        }

        //Link naar admin restaurant overzicht
        public ActionResult Restaurants()
        {
            return View(repository.GetAllRestaurants().OrderBy(x => x.name));
        }

        //Verwijder film uit database
        public ActionResult DeleteFilm(int id)
        {
            if(repository.GetFilmById(id) != null)
            {
                DeleteImageByItemId(id);
                repository.DeleExhibitionsForFilm(id);
                repository.DeleteItem(id);
                return RedirectToAction("Films");
            }
            else
            {
                return RedirectToAction("Index", "Error", new { errorMessage = "This film does not exist." });
            }
            
        }

        //Verwijder special uit database
        public ActionResult DeleteSpecial(int id)
        {
            if(repository.GetItemById(id) != null && repository.GetItemById(id) is Specials)
            {
                DeleteImageByItemId(id);
                repository.DeleteItem(id);
                return RedirectToAction("Specials");
            }
            else
            {
                return RedirectToAction("Index", "Error", new { errorMessage = "This special does not exist." });
            }
            
        }

        //Verwijder restaurant uit database
        public ActionResult DeleteRestaurant(int id)
        {
            if(repository.GetItemById(id) != null && repository.GetItemById(id) is Restaurants)
            {
                DeleteImageByItemId(id);
                repository.DeleteItem(id);
                return RedirectToAction("Restaurants");
            }
            else
            {
                return RedirectToAction("Index", "Error", new { errorMessage = "This restaurant does not exist." });
            }
        }

        //Haal film uit database om te wijzigen
        public ActionResult EditFilm(int id)
        {
            if(repository.GetFilmById(id) != null)
            {
                FilmsViewModel viewModel = new FilmsViewModel();
                viewModel.film = repository.GetFilmById(id);
                viewModel.exhibitions = repository.GetExhibitionForFilmID(id);
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index", "Error", new { errorMessage = "This film does not exist." });
            }

        }

        [HttpPost]
        public ActionResult EditFilm(FilmsViewModel filmViewModel, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                //Verwijder oude afbeelding en upload nieuwe afbeelding wanneer deze is gewijzigd
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
                    exhibition.filmId = filmViewModel.film.id;
                    UpdateExhibition(exhibition);                    
                }
                return RedirectToAction("Films");
            }
            else
            {
                ModelState.AddModelError("Oops", "Something went wrong.");
                return View(filmViewModel);
            }
        }

        //Voeg nieuwe film toe
        public ActionResult AddFilm()
        {
            FilmsViewModel filmsViewModel = InitFilmsViewModel();
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
                if(repository.GetFilmByName(filmViewModel.film.name) == null)
                {
                    repository.AddItem(filmViewModel.film);
                    Items item = repository.GetFilmByName(filmViewModel.film.name);
                    foreach (var exhibition in filmViewModel.exhibitions)
                    {
                        exhibition.filmId = item.id;
                        if (exhibition.startTime != baseTime)
                        {
                            repository.AddFilmExhibition(exhibition);
                        }
                    }
                }


                else
                {
                    ModelState.AddModelError("", "A film with that name already exists");
                    return View(filmViewModel);
                }
                               
                ModelState.Clear();
                TempData["Success"] = "Film successfully added.";
                return RedirectToAction("AddFilm");
            }
            else
            {
                ModelState.AddModelError("Oops", "Something went wrong.");
                return View(filmViewModel);
            }
        }

        //Haal special uit database om te wijzigen
        public ActionResult EditSpecial(int id)
        {
            if (repository.GetItemById(id) != null && repository.GetItemById(id) is Specials)
            {
                return View(repository.GetItemById(id));
            }
            else
            {
                return RedirectToAction("Index", "Error", new { errorMessage = "This special does not exist." });
            }
            
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
                return View(special);
            }
            
        }

        //Voeg special toe
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
                TempData["Success"] = "Special successfully added.";
                return View();
            }
            else
            {
                ModelState.AddModelError("Oops", "Something went wrong.");
                return View(special);
            }
            
        }

        //Haal restaurant uit database om te wijzigen
        public ActionResult EditRestaurant(int id)
        {
            if (repository.GetItemById(id) != null && repository.GetItemById(id) is Restaurants)
            {
                return View(repository.GetItemById(id));
            }
            else
            {
                return RedirectToAction("Index", "Error", new { errorMessage = "This restaurant does not exist." });
            }
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
                return View(restaurant);
            }
            
        }

        //Voeg restaurant toe
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
                TempData["Success"] = "Restaurant successfully added.";
                return View();
            }
            else
            {
                ModelState.AddModelError("Oops", "Something went wrong.");
                return View(restaurant);
            }
            
        }

        //Update filmtentoonstellingen
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
                if(exhibition.startTime == baseTime)
                {
                    repository.DeleteExhibition(exhibition.id);
                }
            }
        }

        //Verwijder afbeelding van een item.
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

        //Intitialiseer het filmsviewmodel voor een nieuwe film.
        public FilmsViewModel InitFilmsViewModel()
        {
            FilmsViewModel filmsViewModel = new FilmsViewModel();
            filmsViewModel.exhibitions.Add(new Exhibitions());
            filmsViewModel.exhibitions.Add(new Exhibitions());
            filmsViewModel.exhibitions[0].startTime = baseTime;
            filmsViewModel.exhibitions[0].endTime = baseTime;
            filmsViewModel.exhibitions[1].startTime = baseTime;
            filmsViewModel.exhibitions[1].endTime = baseTime;
            return filmsViewModel;
        }
    }
}