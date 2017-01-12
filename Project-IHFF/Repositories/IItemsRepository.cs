using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_IHFF.Models;

namespace Project_IHFF.Repositories
{
    interface IItemsRepository
    {
        IEnumerable<Items> GetItemsByOrderId();
        void AddItem(Items item);
        void AddFilmExhibition(Exhibitions filmExhibition);

        void UpdateItem(Items item);
        void UpdateExhibition(Exhibitions exhibition);

        void DeleteItem(int id);
        void DeleteExhibition(Exhibitions exhibition);
        void DeleExhibitionsForFilm(int id);

        Items GetItemById(int id);
        Items GetItemByName(string name);
        Films GetFilmById(int id);
        List<Exhibitions> GetExhibitionForFilmID(int id);

        IEnumerable<Items> GetAllItems();
        IEnumerable<Films> GetAllFilms();
        IEnumerable<Specials> GetAllSpecials();
        IEnumerable<Restaurants> GetAllRestaurants();
    }

    public class DbItemsRepository : IItemsRepository
    {
        private ModelContainer ctx = new ModelContainer();

        public IEnumerable<Items> GetItemsByOrderId()
        {
            throw new NotImplementedException();
        }

        public void AddItem(Items item)
        {
            ctx.Items.Add(item);
            ctx.SaveChanges();
        }

        public void AddFilmExhibition(Exhibitions Exhibition)
        {
            ctx.Exhibitions.Add(Exhibition);
            ctx.SaveChanges();
        }

        public Items GetItemById(int id)
        {
            return ctx.Items.SingleOrDefault(x => x.id == id);
        }

        public Items GetItemByName(string name)
        {
            Items item = ctx.Items.SingleOrDefault(x => x.name == name);
            return item;
        }

        public IEnumerable<Items> GetAllItems()
        {
            return ctx.Items.ToList();
        }

        public Films GetFilmById(int id)
        {
            return ctx.Items.OfType<Films>().SingleOrDefault(x => x.id == id);
        }

        public List<Exhibitions> GetExhibitionForFilmID(int id)
        {
            return ctx.Exhibitions.Where(x => x.filmId == id).ToList();
        }

        public void UpdateItem(Items item)
        {
            Items updateItem = ctx.Items.SingleOrDefault(x => x.id == item.id);
            if(updateItem != null)
            {
                ctx.Entry(updateItem).CurrentValues.SetValues(item);
                ctx.SaveChanges();
            }            
        }

        public void DeleteItem(int id)
        {
            Items deleteItem = ctx.Items.SingleOrDefault(x => x.id == id);
            ctx.Items.Remove(deleteItem);
            ctx.SaveChanges();
        }

        public void UpdateExhibition(Exhibitions exhibition)
        {
            Exhibitions updateExhibition = ctx.Exhibitions.SingleOrDefault(x => x.id == exhibition.id);
            if (updateExhibition != null)
            {
                ctx.Entry(updateExhibition).CurrentValues.SetValues(exhibition);
                ctx.SaveChanges();
            }

        }
        
        public void DeleteExhibition(Exhibitions exhibition)
        {
            ctx.Exhibitions.Remove(exhibition);
        }

        public void DeleExhibitionsForFilm(int id)
        {
            Films film = ctx.Items.OfType<Films>().SingleOrDefault(x => x.id == id);
            List<Exhibitions> exhibitions = GetExhibitionForFilmID(id);
            foreach(var x in exhibitions)
            {
                ctx.Exhibitions.Remove(x);
            }
        }

        public IEnumerable<Films> GetAllFilms()
        {
            return ctx.Items.OfType<Films>().ToList();
        }

        public IEnumerable<Specials> GetAllSpecials()
        {
            return ctx.Items.OfType<Specials>().ToList();
        }

        public IEnumerable<Restaurants> GetAllRestaurants()
        {
            return ctx.Items.OfType<Restaurants>().ToList();
        }
    }
}