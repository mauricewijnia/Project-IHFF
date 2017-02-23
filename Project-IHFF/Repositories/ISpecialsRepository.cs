using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_IHFF.Models;
using System.Data.Entity.SqlServer;

namespace Project_IHFF.Repositories
{
    interface ISpecialsRepository
    {
        IEnumerable<SpecialViewModel> GetAllSpecials();
        IEnumerable<SpecialViewModel> GetAllRestaurant();
    }

    public class DbSpecialsRepository : ISpecialsRepository
    {
        private ModelContainer ctx = new ModelContainer();
        public IEnumerable<SpecialViewModel> GetAllSpecials()
        {
            var query = (from Specials in ctx.Items.OfType<Specials>()
                         join items in ctx.Items on Specials.id equals items.id
                         orderby Specials.endTime ascending
                         select new SpecialViewModel()
                         {
                             ItemId = Specials.id,
                             Description = Specials.description,
                             Location = Specials.location,
                             Price = Specials.price,
                             Name = Specials.name,

                             Host = Specials.host,
                             StartTime = Specials.startTime,
                             EndTime = Specials.endTime

                         }).ToList();
            return query;
        }
        public IEnumerable<SpecialViewModel> GetAllRestaurant()
        {
            
            var query = (from RestaurantReservation in ctx.Items.OfType<Restaurants>()
                         join items in ctx.Items on RestaurantReservation.id equals items.id
                         select new SpecialViewModel()
                         {
                             ItemId = RestaurantReservation.id,
                             Description = RestaurantReservation.description,
                             Location = RestaurantReservation.location,
                             Price = RestaurantReservation.price,
                             Name = RestaurantReservation.name                             

                         }).ToList();
            return query;
        }
    }
}