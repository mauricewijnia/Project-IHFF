﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_IHFF.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
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