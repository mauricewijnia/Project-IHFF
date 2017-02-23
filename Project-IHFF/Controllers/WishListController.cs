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
    public class WishListController : Controller
    {
        // GET: WishList
        public ActionResult Index()
        {
            List<Tickets> tickets = new List<Tickets>();
            if (Session["wishlist"] != null)
            {
                tickets = Session["wishlist"] as List<Tickets>;
            }

            Session["wishlist"] = tickets;           
            return View(tickets);
        }
    }
}