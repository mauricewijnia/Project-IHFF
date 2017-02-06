using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_IHFF.Models;
//using Project_IHFF.Interfaces;
using Project_IHFF.Repositories;

namespace Project_IHFF.Controllers
{
    public class FilmController : Controller
    {


        private IFilmRepository filmRepository = new DbFilmRepository();
        // GET: Film
        public ActionResult Index()
        {
            /*
            List<Films> films = filmRepository.GetAllFilmsToList();
            List<Exhibitions> exhibitions = filmRepository.GetAllExhibitions();
            List<FilmsViewModel> items = new List<FilmsViewModel>();
            foreach (Films film in films)
            {
                var viewModel = new FilmsViewModel();
                viewModel.film = film;
                viewModel.exhibitions = new List<Exhibitions>();
                viewModel.exhibitions = exhibitions.FindAll(x => x.filmId == film.id);
                items.Add(viewModel);
            }*/

            IEnumerable<ExhibitionViewModel> allFilms = filmRepository.GetAllFilms();

            
            //IEnumerable<FilmViewModel> allItems = filmRepository.GetAllFilms();

            return View(allFilms);


            /*
            // fake shit--------------------------------------------------------------------------------

            List<Tickets> tickets = new List<Tickets>();

            //fake Film
            Films film = new Films();
            film.name = "2Girls1Cup";
            film.price = 7;

            //Fake Exobision
            Exhibitions exo = new Exhibitions();
            exo.endTime = new DateTime(2016, 3, 9, 17, 5, 7, 123);
            exo.startTime = new DateTime(2016, 3, 9, 16, 5, 7, 123);
            exo.filmId = 6;
            exo.Films = film;


            //fake FilmTicket;
            FilmTickets FilmtTicket = new FilmTickets();
            FilmtTicket.id = 6;
            FilmtTicket.orderId = 4;
            FilmtTicket.quantity = 2;
            FilmtTicket.FilmExhibitions = exo;
            tickets.Add(FilmtTicket);

            // -------------------------------------------------- 2e ticket
            //fake Film
            Films film2 = new Films();
            film2.name = "SexInTheSicty";
            film2.price = 2;
            //Fake Exobision
            Exhibitions exo2 = new Exhibitions();
            exo2.endTime = new DateTime(2016, 3, 9, 17, 3, 7, 123);
            exo2.startTime = new DateTime(2016, 3, 9, 16, 3, 2, 123);
            exo2.filmId = 5;
            exo2.Films = film2;

            
            //fake FilmTicket;
            FilmTickets FilmtTicket2 = new FilmTickets();
            FilmtTicket2.id = 5;
            FilmtTicket2.orderId = 4;
            FilmtTicket2.quantity = 9;
            FilmtTicket2.FilmExhibitions = exo2;
            tickets.Add(FilmtTicket2);

            // -------------------------------------------------- 3e ticket
            Restaurants restauranttje = new Restaurants();
            restauranttje.name = "McDonalds";
            restauranttje.id = 12;

            RestaurantReservation restaurant = new RestaurantReservation();
            restaurant.id = 22;
            restaurant.reservationTime = new DateTime(2016, 3, 9, 20, 1, 3, 123);
            restaurant.quantity = 3;
            restaurant.Restaurants = restauranttje;
            tickets.Add(restaurant);

            // -------------------------------------------------- 4e ticket
            Specials specialtje = new Specials();
            specialtje.name = "Prater";
            specialtje.startTime = new DateTime(2016, 3, 8, 13, 2, 3, 123);
            specialtje.endTime = new DateTime(2016, 3, 8, 15, 2, 3, 123);

            SpecialTicket special = new SpecialTicket();
            special.id = 23;
            special.quantity = 3;
            special.Specials = specialtje;
            tickets.Add(special);
            //--------------------------------------------------------------- STOP FAKE

            Session["Tickets"] = tickets; //gooi de lijst met alle tickets in deze Session pls :)
            return View(tickets);*/
        }

        public virtual ActionResult FilmsView(string day)
        {
            int dayNr = 0;
            switch (day)
            {
                //dayNr is +1 
                //query comparision with datetime adds one day to datetime when turned in day
                case "monday": dayNr = 2; break;
                case "tuesday": dayNr = 3; break;
                case "wednesday": dayNr = 4; break;
                case "thursday": dayNr = 5; break;
                case "friday": dayNr = 6; break;
                case "saturday": dayNr = 7; break;
                case "sunday": dayNr = 8; break;
            }
            //if dayNr = 0 (no day filter is set) get all films. otherwise a dayNr is set above and "GetFilmsByDay" is triggerd
            IEnumerable<ExhibitionViewModel> filmList = (dayNr == 0) ? filmRepository.GetAllFilms() : filmRepository.GetFilmsByDay(dayNr);
            return PartialView(filmList);
        }

        public PartialViewResult SortedFilms(int day, string sort)
        {

            return PartialView();

            //db.Racers.Where(r => r.Country == id).OrderByDescending(r => r.Wins).ThenBy(r => r.Lastname).ToList()
        }
    }
}