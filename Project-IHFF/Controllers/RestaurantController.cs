using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_IHFF.Models;
using Project_IHFF.Repositories;

namespace Project_IHFF.Controllers
{
    public class RestaurantController : Controller
    {


        private IRestaurantRepository restaurantRepository = new DbRestaurantRepository();

        public ActionResult Index()
        {

            IEnumerable<RestaurantViewModel> allRestaurants = restaurantRepository.GetAllRestaurants();

            return View(allRestaurants);
        }

    }
}