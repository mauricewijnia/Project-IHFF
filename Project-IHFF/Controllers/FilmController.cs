using Project_IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_IHFF.Controllers
{
    public class FilmController : Controller
    {
        // GET: Film
        public ActionResult Index()
        {

            // fake shit--------------------------------------------------------------------------------

            List<Tickets> tickets = new List<Tickets>();

            //fake Film
            Films film = new Films();
            film.name = "2Girls1Cup";
            film.price = 7;

            //Fake Exobision
            FilmExhibitions exo = new FilmExhibitions();
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

            //fake Film
            Films film2 = new Films();
            film2.name = "SexInTheSicty";
            film2.price = 2;
            // -------------------------------------------------- 2e ticket
            //Fake Exobision
            FilmExhibitions exo2 = new FilmExhibitions();
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
            //---------------------------------------------------------------

            Session["Tickets"] = tickets; //gooi de lijst met alle tickets in deze Session pls :)
            return View(tickets);
        }
    }
}