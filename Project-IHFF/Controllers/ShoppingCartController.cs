using Project_IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Project_IHFF.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart

        public ActionResult Index()
        {
            List<Tickets> tickets = new List<Tickets>();
            if (Session["products"] != null)
            {
                tickets = Session["products"] as List<Tickets>;
            }

            Session["Products"] = tickets;
            decimal totaalprijs = 0;
            decimal Korting = 0;

            if (Session["products"] as List<Tickets> != null) //alleen bereken als er iets te berekenen valt
            {
                foreach (Tickets film in Session["products"] as List<Tickets>) // berekent totaalprijs
                {
                    if (film is FilmTickets)
                    {
                        Exhibitions exo = (((FilmTickets)film).FilmExhibitions);
                        Films filmpje = exo.Films;
                        Orders order = new Orders();
                        if (tickets.Count > 1)
                        {
                            totaalprijs = totaalprijs + (filmpje.price * film.quantity);
                            Korting = totaalprijs * (decimal)0.05;
                        }
                        totaalprijs = totaalprijs - Korting;
                    }
                    
                }
            }
            ViewBag.TotaalPrijs = totaalprijs;
            ViewBag.Korting = Korting;

            return View(tickets);
        }

        public ActionResult Add(int id, int Quantity)
        {
            Tickets ticket = new Tickets();



            foreach (Tickets film in Session["Tickets"] as List<Tickets>) // zoek toegevoegde ticket in lijst met alle tickets
            {
                if (film.id == id)
                {
                    ticket = film;
                    ticket.quantity = Quantity;
                }
            }


            List<Tickets> tickets = new List<Tickets>();
            if (Session["products"] != null) // haal lijst met producten van winkelwagentje op als ze er zijn
            {
                tickets = Session["products"] as List<Tickets>;
            }

            int test = 1;
            if (Session["products"] as List<Tickets> != null) // als winkelmandje leeg is moet product sws worden toegevoegd
            {
                foreach (Tickets film in Session["products"] as List<Tickets>) // kijk of toegevoegde ticket al bestaat in winkelwagentje
                {
                    if (film.id == id)
                    {
                        film.quantity = film.quantity + Quantity; // hoog de quantity op in plaats van hem toe te voegen
                        test = 2;
                    }
                }
                if (test == 1) //als de Quantity niet veranderd is, toevoegen
                {
                    tickets.Add(ticket);
                }
            }
            else
            {
                tickets.Add(ticket);
            }


            Session["Products"] = tickets;
            return RedirectToAction("Index");
        }
        public ActionResult Remove()
        {
            return View();
        }
        public ActionResult UpQuantity(int id)
        {
            List<Tickets> tickets = Session["products"] as List<Tickets>;

            foreach (Tickets ticket in tickets)
            {
                if (ticket is FilmTickets)
                {
                    if ((((FilmTickets)ticket).id) == id)
                    {
                        (((FilmTickets)ticket).quantity)++;
                    }                   
                }
                else if (ticket is RestaurantReservation)
                {
                    if ((((RestaurantReservation)ticket).id) == id)
                    {
                        (((RestaurantReservation)ticket).quantity)++;
                    }
                }
                else if (ticket is SpecialTicket)
                {
                    if ((((SpecialTicket)ticket).id) == id)
                    {
                        (((SpecialTicket)ticket).quantity)++;
                    }
                }
            }

            Session["Products"] = tickets;
            return RedirectToAction("Index");
        }

        public ActionResult DownQuantity(int id)
        {
            List<Tickets> tickets = Session["products"] as List<Tickets>;

            foreach (Tickets ticket in tickets)
            {
                if (ticket is FilmTickets)
                {
                    if ((((FilmTickets)ticket).id) == id)
                    {
                        (((FilmTickets)ticket).quantity)--;
                    }
                  
                }
                else if (ticket is RestaurantReservation)
                {
                    if ((((RestaurantReservation)ticket).id) == id)
                    {
                        (((RestaurantReservation)ticket).quantity)--;
                    }
                }
                else if (ticket is SpecialTicket)
                {
                    if ((((SpecialTicket)ticket).id) == id)
                    {
                        (((SpecialTicket)ticket).quantity)--;
                    }
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