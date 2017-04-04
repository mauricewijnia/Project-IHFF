using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_IHFF.Models;
using System.Data.Entity.SqlServer;

namespace Project_IHFF.Repositories
{
    interface IRestaurantRepository
    {
        IEnumerable<RestaurantViewModel> GetAllRestaurants();
    }

    public class DbRestaurantRepository : IRestaurantRepository
    {
        private ModelContainer ctx = new ModelContainer();
        public IEnumerable<RestaurantViewModel> GetAllRestaurants()
        {
            var query = (from restaurants in ctx.Items.OfType<Restaurants>()
                         join items in ctx.Items on restaurants.id equals items.id
                         orderby items.name ascending
                         select new RestaurantViewModel()
                         {
                             ItemId = restaurants.id,
                             Name = items.name,
                             Description = items.description,
                             Image = items.imagePath,
                             Location = items.location,
                             Price = items.price,
                             TimeOpen = restaurants.timeOpen,
                             TimeClosed = restaurants.timeClosed

                         }).ToList();
            return query;
        }

    }

}
