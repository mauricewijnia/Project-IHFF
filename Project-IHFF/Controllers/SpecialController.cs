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
    public class SpecialController : Controller
    {


        private ISpecialRepository specialRepository = new DbSpecialRepository();
        // GET: Special
        public ActionResult Index()
        {

            IEnumerable<SpecialViewModel> allSpecial = specialRepository.GetAllSpecials();

            return View(allSpecial);
        }

        public virtual ActionResult SpecialsView(string day, string place, string sort)
        {
            //a code to check wich filters are active, and wich query to run
            string filterCode = (day != null) ? "1" : "0";
            filterCode = (place != null) ? filterCode + "1" : filterCode + "0";
            filterCode = (sort == "sortName") ? filterCode + "1" : filterCode + "0";

            int dayNr = 0;
            if (day != null) {
                switch (day)
                {
                    case "sunday": dayNr = 1; break;
                    case "monday": dayNr = 2; break;
                    case "tuesday": dayNr = 3; break;
                    case "wednesday": dayNr = 4; break;
                    case "thursday": dayNr = 5; break;
                    case "friday": dayNr = 6; break;
                    case "saturday": dayNr = 7; break;
                }
            }

        
            IEnumerable<SpecialViewModel> specialList = specialRepository.GetAllSpecials();
            //fill filmlist with correct filters applied
            switch (filterCode)
            {
                case "100": specialList = specialRepository.GetSpecialsByDay(dayNr); break;
                case "010": specialList = specialRepository.GetSpecialsByPlace(place); break;
                case "110": specialList = specialRepository.GetSpecialsByDayPlace(dayNr, place); break;
                case "001": specialList = specialRepository.GetAllSpecialsByTitle(); break;
                case "101": specialList = specialRepository.GetSpecialsByDayTitle(dayNr); break;
                case "011": specialList = specialRepository.GetSpecialsByPlaceTitle(place); break;
                case "111": specialList = specialRepository.GetSpecialsByDayPlaceTitle(dayNr, place); break;
                default: specialList = specialRepository.GetAllSpecials(); break;
            }

            return PartialView(specialList);
        }

    }
}