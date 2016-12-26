using Project_IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_IHFF.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart

        public ActionResult Index(/*Tickets ticket*/)
        {
            List<Tickets> tickets = new List<Tickets>();
            if (Session["products"] != null)
            {
                tickets = Session["products"] as List<Tickets>;
            }
            else
            {
                //fake shit --------------------------------------------------------------------------------

                //fake Film
                Films film = new Films();
                film.name = "2Girls1Cup";
                film.price = 7;

                //Fake Exobision
                FilmExhibitions exo = new FilmExhibitions();
                exo.endTime = new DateTime(2016, 3, 9, 17, 5, 7, 123);
                exo.startTime = new DateTime(2016, 3, 9, 16, 5, 7, 123);
                exo.filmId = 1;
                exo.Films = film;


                //fake FilmTicket;
                FilmTickets FilmtTicket = new FilmTickets();
                FilmtTicket.id = 6;
                FilmtTicket.orderId = 4;
                FilmtTicket.quantity = 2;
                FilmtTicket.FilmExhibitions = exo;
                
                //---------------------------------------------------------------

                //fake Film
                Films film2 = new Films();
                film2.name = "Filmpje";
                film2.price = 6;

                //Fake Exobision
                FilmExhibitions exo2 = new FilmExhibitions();
                exo2.endTime = new DateTime(2016, 3, 10, 18, 5, 7, 123);
                exo2.startTime = new DateTime(2016, 3, 10, 19, 2, 7, 123);
                exo2.filmId = 1;
                exo2.Films = film2;

                //fake FilmTicket;
                FilmTickets FilmtTicket2 = new FilmTickets();
                FilmtTicket2.id = 6;
                FilmtTicket2.orderId = 4;
                FilmtTicket2.quantity = 2;
                FilmtTicket2.FilmExhibitions = exo;
                // stop fake -----------------------------------------------------------------------------

                foreach (FilmTickets filmtichet in tickets)
                {
                    if (FilmtTicket2.id == filmtichet.id)
                    {
                        filmtichet.quantity = filmtichet.quantity + FilmtTicket2.quantity;
                    }
                    else
                    {
                        tickets.Add(FilmtTicket2);
                    }
                }

                tickets.Add(FilmtTicket);
            }


            Session["Products"] = tickets;
            return View(tickets);
        }

        public ActionResult Add(/*Tickets ticket*/)
        {
            return View();
        }
        public ActionResult Remove()
        {
            return View();
        }
        public ActionResult UpQuantity(int id)
        {
            List<Tickets> tickets = Session["products"] as List<Tickets>;

            foreach (FilmTickets film in tickets)
            {
                if (film.id == id)
                {
                    film.quantity++;
                }
            }

            Session["Products"] = tickets;
            return RedirectToAction("Index");
        }

        public ActionResult DownQuantity(int id)
        {
            List<Tickets> tickets = Session["products"] as List<Tickets>;

            foreach (FilmTickets film in tickets)
            {
                if (film.id == id)
                {
                    film.quantity--;
                }
            }

            Session["Products"] = tickets;
            return RedirectToAction("Index");
        }

        public ActionResult Purchase()
        {
            return View();
        }
    }
}