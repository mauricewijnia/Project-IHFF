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
        private ISpecialsRepository specialsRepository = new DbSpecialsRepository();
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
                        }
                        else
                        {
                            totaalprijs = filmpje.price * film.quantity;
                        }
                    }
                }
                if (tickets.Count > 1)
                {
                    Korting = totaalprijs * (decimal)0.05;
                    totaalprijs = totaalprijs - Korting;
                }
            }
            ViewBag.TotaalPrijs = totaalprijs;
            ViewBag.Korting = Korting;

            return View(tickets);
        }


        public ActionResult Add(int id, int Quantity, bool shopcart, bool remove, DateTime tijd)
        {
            Tickets ticket = new Tickets();
            List<Tickets> Alltickets = AllTickets();
            List<Tickets> tickets = new List<Tickets>();

            string sessie;

            if (!shopcart) //als het naar shopping cart doe wishlist sessie en anders product sessie
            {
                sessie = "wishlist";
            }
            else
            {
                sessie = "products";
            }

            foreach (Tickets item in Alltickets) // zoek toegevoegde ticket in lijst met alle tickets
            {
                if (item.id == id)
                {
                    if (item is RestaurantReservation)
                    {
                        ticket = RestaurantToevoegen(((RestaurantReservation)item), Quantity, tijd);
                    }
                    else
                    {
                        ticket = item;
                        ticket.quantity = Quantity;
                    }
                }
            }
            if (Session[sessie] != null) // haal lijst met producten van winkelwagentje op als ze er zijn
            {
                tickets = Session[sessie] as List<Tickets>;
            }

            int breaker = 1;
            if (Session[sessie] as List<Tickets> != null) // als winkelmandje leeg is moet product sws worden toegevoegd
            {
                foreach (Tickets film in Session[sessie] as List<Tickets>) // kijk of toegevoegde ticket al bestaat in winkelwagentje
                {
                    if (film.id == id)
                    {
                        film.quantity = film.quantity + Quantity; // hoog de quantity op in plaats van hem toe te voegen
                        breaker = 2;
                    }
                }
                if (breaker == 1) //als de Quantity niet veranderd is, toevoegen
                {
                    tickets.Add(ticket);
                }
            }
            else
            {
                tickets.Add(ticket);
            }

            

            Session[sessie] = tickets;
            if (remove)
            {
                bool shopping = false;
                return RedirectToAction("Remove", new { id = id, shopcart = shopping });
            }

            if (shopcart)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "WishList");
            }

        }

        private Tickets RestaurantToevoegen(RestaurantReservation res, int Quantity, DateTime tijd)
        {
            Restaurants restauranttje = (((RestaurantReservation)res).Restaurants);            

            Restaurants restaurattje = new Restaurants();
            restauranttje.name = restauranttje.name;
            restauranttje.id = restauranttje.id;
            restauranttje.price = 10;

            RestaurantReservation restaurant = new RestaurantReservation();
            restaurant.id = res.id;
            restaurant.reservationTime = tijd;
            restaurant.quantity = Quantity;
            restaurant.Restaurants = restauranttje;
            

            return restaurant;
        }

        private List<Tickets> AllTickets()
        {
            List<Tickets> tickets = new List<Tickets>();
            IEnumerable<ExhibitionViewModel> allFilms = filmRepository.GetAllFilms();
            foreach (ExhibitionViewModel exo in allFilms)
            {
                Films film2 = new Films();
                film2.name = exo.Name;
                film2.price = exo.Price;
                film2.id = exo.FilmId;

                //Exobision
                Exhibitions exo2 = new Exhibitions();
                exo2.endTime = exo.EndTime;
                exo2.startTime = exo.StartTime;
                exo2.filmId = exo.FilmId;
                exo2.Films = film2;
                exo.ExhibitionId = film2.id;

                //FilmTicket;
                FilmTickets FilmtTicket2 = new FilmTickets();
                FilmtTicket2.id = exo.FilmId;
                FilmtTicket2.ExhibitionsSet = exo2;
                tickets.Add(FilmtTicket2);
            }
            IEnumerable<SpecialViewModel> allRestaurant = specialsRepository.GetAllRestaurant();
            foreach (SpecialViewModel rest in allRestaurant)
            {
                Restaurants restauranttje = new Restaurants();
                restauranttje.name = rest.Name;
                restauranttje.id = rest.ItemId;

                RestaurantReservation restaurant = new RestaurantReservation();
                restaurant.id = rest.ItemId;
                restaurant.reservationTime = rest.StartTime;
                restaurant.quantity = 0;
                restaurant.Restaurants = restauranttje;
                tickets.Add(restaurant);
            }
            IEnumerable<SpecialViewModel> allSpecials = specialsRepository.GetAllSpecials();
            foreach (SpecialViewModel spec in allSpecials)
            {
                Specials specialtje = new Specials();
                specialtje.name = spec.Name;
                specialtje.startTime = spec.StartTime;
                specialtje.endTime = spec.EndTime;

                SpecialTicket special = new SpecialTicket();
                special.id = spec.ItemId;
                special.quantity = 0;
                special.Specials = specialtje;
                tickets.Add(special);
            }

            return tickets;
        }

        public ActionResult Remove(int id, bool shopcart)
        {
            string sessie;
            if (!shopcart) //als het naar shopping cart doe wishlist sessie en anders product sessie
            {
                sessie = "wishlist";
            }
            else
            {
                sessie = "products";
            }
            List<Tickets> tickets = Session[sessie] as List<Tickets>;
            List<Tickets> tickets2 = new List<Tickets>();
            foreach (Tickets ticket in tickets)
            {
                if (ticket.id != id)
                {
                    tickets2.Add(ticket);
                }
            }

            Session[sessie] = tickets2;

            if (shopcart)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "WishList");
            }
        }
        public ActionResult ChangeQuantity(int id, int aantal, bool shopcart)
        {
            string sessie;
            if (!shopcart) //als het naar shopping cart doe wishlist sessie en anders product sessie
            {
                sessie = "wishlist";
            }
            else
            {
                sessie = "products";
            }
            List<Tickets> tickets = Session[sessie] as List<Tickets>;

            foreach (Tickets ticket in tickets)
            {
                if (ticket.id == id)
                {
                    ticket.quantity = ticket.quantity + aantal;
                }
            }

            Session[sessie] = tickets;

            if (shopcart)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "WishList");
            }
        }

        public ActionResult Purchase()
        {
            return View();
        }
        public ActionResult MoveAllToCart()
        {
            List<Tickets> Wishtickets = new List<Tickets>();
            List<Tickets> tickets = new List<Tickets>();

            if (Session["WishList"] != null) // haal lijst met producten van Wishlist op als ze er zijn
            {
                Wishtickets = Session["WishList"] as List<Tickets>;

                Session["WishList"] = null; // maak wishlist leeg
            }

            if (Session["products"] != null) // haal lijst met producten van winkelwagentje op als ze er zijn
            {
                tickets = Session["products"] as List<Tickets>;
            }

            foreach (Tickets ticket in Wishtickets) // voeg alle wishlisttickets toe aan shoppingcartList
            {
                tickets.Add(ticket);
            }

            Session["Products"] = tickets;

            return RedirectToAction("Index");
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