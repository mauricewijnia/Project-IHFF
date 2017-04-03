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

            IEnumerable<ExhibitionViewModel> allFilms = filmRepository.GetAllFilms();


            return View(allFilms);
        }

        public virtual ActionResult FilmsView(string day, string place, string sort)
        {
            //a code to check wich filters are active, and wich query to run
            string filterCode = (day != null) ? "1" : "0";
            filterCode = (place != null) ? filterCode + "1" : filterCode + "0";
            filterCode = (sort == "sortName") ? filterCode + "1" : filterCode + "0";

            int dayNr = 0;
            if (day != null) {
                switch (day)
                {
                    //dayNr is +1 
                    //query comparision with datetime adds one day to datetime when turned in day
                    case "sunday": dayNr = 1; break;
                    case "monday": dayNr = 2; break;
                    case "tuesday": dayNr = 3; break;
                    case "wednesday": dayNr = 4; break;
                    case "thursday": dayNr = 5; break;
                    case "friday": dayNr = 6; break;
                    case "saturday": dayNr = 7; break;
                    
                }
            }

            IEnumerable<ExhibitionViewModel> filmList;
            //fill filmlist with correct filters applied
            switch (filterCode)
            {
                case "100": filmList = filmRepository.GetFilmsByDay(dayNr); break;
                case "010": filmList = filmRepository.GetFilmsByPlace(place); break;
                case "110": filmList = filmRepository.GetFilmsByDayPlace(dayNr, place); break;
                case "001": filmList = filmRepository.GetAllFilmsByTitle(); break;
                case "101": filmList = filmRepository.GetFilmsByDayTitle(dayNr); break;
                case "011": filmList = filmRepository.GetFilmsByPlaceTitle(place); break;
                case "111": filmList = filmRepository.GetFilmsByDayPlaceTitle(dayNr, place); break;
                default: filmList = filmRepository.GetAllFilms(); break;
            }

            return PartialView(filmList);
        }

    }
}