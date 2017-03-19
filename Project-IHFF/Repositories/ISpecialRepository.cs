using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_IHFF.Models;
using System.Data.Entity.SqlServer;

namespace Project_IHFF.Repositories
{
    interface ISpecialRepository
    {
        IEnumerable<SpecialViewModel> GetAllSpecials();
        IEnumerable<SpecialViewModel> GetSpecialsByDay(int day);
        IEnumerable<SpecialViewModel> GetSpecialsByPlace(string place);
        IEnumerable<SpecialViewModel> GetSpecialsByDayPlace(int day, string place);
        IEnumerable<SpecialViewModel> GetAllSpecialsByTitle();
        IEnumerable<SpecialViewModel> GetSpecialsByDayTitle(int day);
        IEnumerable<SpecialViewModel> GetSpecialsByPlaceTitle(string place);
        IEnumerable<SpecialViewModel> GetSpecialsByDayPlaceTitle(int day, string place);
    }

    public class DbSpecialRepository : ISpecialRepository
    {
        private ModelContainer ctx = new ModelContainer();
        public IEnumerable<SpecialViewModel> GetAllSpecials()
        {
            var query = (from specials in ctx.Items.OfType<Specials>()
                         join items in ctx.Items on specials.id equals items.id
                         orderby specials.endTime ascending
                         select new SpecialViewModel()
                         {
                             ItemId = specials.id,
                             Name = items.name,
                             Description = items.description,
                             Host = specials.host,
                             Image = items.imagePath,
                             Location = SqlFunctions.DatePart("dw", specials.startTime).ToString(),
                             Price = items.price,
                             Capacity = specials.capacity,
                             StartTime = specials.startTime,
                             EndTime = specials.endTime

                         }).ToList();
            return query;
        }

        public IEnumerable<SpecialViewModel> GetSpecialsByDay(int day)
        {
            var query = (from specials in ctx.Items.OfType<Specials>()
                         join items in ctx.Items on specials.id equals items.id
                         where SqlFunctions.DatePart("dw", specials.startTime) == day
                         orderby specials.startTime ascending

                         select new SpecialViewModel()
                         {
                             ItemId = specials.id,
                             Name = items.name,
                             Description = items.description,
                             Host = specials.host,
                             Image = items.imagePath,
                             Location = items.location,
                             Price = items.price,
                             Capacity = specials.capacity,
                             StartTime = specials.startTime,
                             EndTime = specials.endTime

                         }).ToList();
            return query;
        }
        public IEnumerable<SpecialViewModel> GetSpecialsByPlace(string place)
        {
            var query = (from specials in ctx.Items.OfType<Specials>()
                         join items in ctx.Items on specials.id equals items.id
                         where items.location.StartsWith(place)
                         orderby specials.startTime ascending

                         select new SpecialViewModel()
                         {
                             ItemId = specials.id,
                             Name = items.name,
                             Description = items.description,
                             Host = specials.host,
                             Image = items.imagePath,
                             Location = items.location,
                             Price = items.price,
                             Capacity = specials.capacity,
                             StartTime = specials.startTime,
                             EndTime = specials.endTime

                         }).ToList();
            return query;
        }

        public IEnumerable<SpecialViewModel> GetSpecialsByDayPlace(int day, string place)
        {
            var query = (from specials in ctx.Items.OfType<Specials>()
                         join items in ctx.Items on specials.id equals items.id
                         where SqlFunctions.DatePart("dw", specials.startTime) == day
                         where items.location.StartsWith(place)
                         orderby specials.startTime ascending

                         select new SpecialViewModel()
                         {
                             ItemId = specials.id,
                             Name = items.name,
                             Description = items.description,
                             Host = specials.host,
                             Image = items.imagePath,
                             Location = items.location,
                             Price = items.price,
                             Capacity = specials.capacity,
                             StartTime = specials.startTime,
                             EndTime = specials.endTime

                         }).ToList();
            return query;      
        }

        public IEnumerable<SpecialViewModel> GetAllSpecialsByTitle()
        {
            var query = (from specials in ctx.Items.OfType<Specials>()
                         join items in ctx.Items on specials.id equals items.id
                         orderby items.name ascending

                         select new SpecialViewModel()
                         {
                             ItemId = specials.id,
                             Name = items.name,
                             Description = items.description,
                             Host = specials.host,
                             Image = items.imagePath,
                             Location = items.location,
                             Price = items.price,
                             Capacity = specials.capacity,
                             StartTime = specials.startTime,
                             EndTime = specials.endTime

                         }).ToList();
            return query;
        }

        public IEnumerable<SpecialViewModel> GetSpecialsByDayTitle(int day)
        {
            var query = (from specials in ctx.Items.OfType<Specials>()
                         join items in ctx.Items on specials.id equals items.id
                         where SqlFunctions.DatePart("dw", specials.startTime) == day
                         orderby items.name ascending

                         select new SpecialViewModel()
                         {
                             ItemId = specials.id,
                             Name = items.name,
                             Description = items.description,
                             Host = specials.host,
                             Image = items.imagePath,
                             Location = items.location,
                             Price = items.price,
                             Capacity = specials.capacity,
                             StartTime = specials.startTime,
                             EndTime = specials.endTime

                         }).ToList();
            return query;
        }
        public IEnumerable<SpecialViewModel> GetSpecialsByPlaceTitle(string place)
        {
            var query = (from specials in ctx.Items.OfType<Specials>()
                         join items in ctx.Items on specials.id equals items.id
                         where items.location.StartsWith(place)
                         orderby items.name ascending

                         select new SpecialViewModel()
                         {
                             ItemId = specials.id,
                             Name = items.name,
                             Description = items.description,
                             Host = specials.host,
                             Image = items.imagePath,
                             Location = items.location,
                             Price = items.price,
                             Capacity = specials.capacity,
                             StartTime = specials.startTime,
                             EndTime = specials.endTime

                         }).ToList();
            return query;
        }

        public IEnumerable<SpecialViewModel> GetSpecialsByDayPlaceTitle(int day, string place)
        {
            var query = (from specials in ctx.Items.OfType<Specials>()
                         join items in ctx.Items on specials.id equals items.id
                         where SqlFunctions.DatePart("dw", specials.startTime) == day
                         where items.location.StartsWith(place)
                         orderby items.name ascending

                         select new SpecialViewModel()
                         {
                             ItemId = specials.id,
                             Name = items.name,
                             Description = items.description,
                             Host = specials.host,
                             Image = items.imagePath,
                             Location = items.location,
                             Price = items.price,
                             Capacity = specials.capacity,
                             StartTime = specials.startTime,
                             EndTime = specials.endTime

                         }).ToList();
            return query;
        }
    }
}