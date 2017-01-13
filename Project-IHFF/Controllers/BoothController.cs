using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_IHFF.Models;
//using Project_IHFF.Interfaces;
using Project_IHFF.Repositories;


public class BoothController : Controller
{
    IShoppingCartRepository shoppingReop = new DbShoppingCartRepository();
    // GET: Booth
    public ActionResult Index()
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

        if (account == null)
        {
            return RedirectToAction("Index", "ShoppingCart");
        }
        Orders order = new Orders();
        order.date = DateTime.Now;
        order.isPaid = "no";
        Random randon = new Random();
        int rnd = randon.Next(1000, 9999);
        order.pickupCode = rnd.ToString();
        account.Orders.Add(order);
        shoppingReop.AddOrder(order, account);
        List<Tickets> ticketsss = new List<Tickets>();
        Session["products"] = ticketsss;
        return View(order);
    }
}
