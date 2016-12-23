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
            Tickets tickett = new Tickets();
            tickett.id = 8;
            tickett.orderId = 3;
            tickett.quantity = 4;
            tickets.Add(tickett);
            return View(tickets);
        }

        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Remove()
        {
            return View();
        }
        public ActionResult ChangeCapacity()
        {
            return View();
        }

        public ActionResult Purchase()
        {
            return View();
        }
    }
}