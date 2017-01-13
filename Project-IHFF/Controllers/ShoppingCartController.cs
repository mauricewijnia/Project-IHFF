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
    public class ShoppingCartController : Controller
    {
        IShoppingCartRepository shoppingReop = new DbShoppingCartRepository();
        // GET: ShoppingCart
        private IFilmRepository filmRepository = new DbFilmRepository();
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
                        Exhibitions exo = (((FilmTickets)film).ExhibitionsSet);
                        Films filmpje = exo.Films;
                        Orders order = new Orders();
                        if (tickets.Count > 1)
                        {
                            totaalprijs = totaalprijs + (filmpje.price * film.quantity);
                            Korting = totaalprijs * (decimal)0.05;
                        }
                        else
                        {
                            totaalprijs = filmpje.price * film.quantity;
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

        public ActionResult Remove(int id)
        {

            List<Tickets> tickets = Session["products"] as List<Tickets>;
            List<Tickets> tickets2 = new List<Tickets>();
            foreach (Tickets ticket in tickets)
            {
                if (ticket.id != id)
                {
                    tickets2.Add(ticket);
                }
            }

            Session["Products"] = tickets2;
            return RedirectToAction("Index");
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
        
        public ActionResult PurchaseDone()
        {
            Accounts account = Session["loggedin_account"] as Accounts;
            List<Tickets> tickets = new List<Tickets>();
            if (Session["products"] != null)
            {
                tickets = Session["products"] as List<Tickets>;
            }
            else
            {
                return RedirectToAction("Index", "ShoppingCart");
            }
            Orders order = new Orders();
            order.date = DateTime.Now;
            order.isPaid = "yes";
            Random randon = new Random();
            int rnd = randon.Next(1000, 9999);
            order.pickupCode = rnd.ToString();
            account.Orders.Add(order);
            shoppingReop.AddOrder(order, account);
            List<Tickets> ticketsss = new List<Tickets>();
            Session["products"] = ticketsss;
            return View();
        }
    }
}