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
        void AddFilmExhibition(FilmExhibition filmExhibition);
    }

    public class InMemoryItemsRepository : IItemsRepository
    {
        public void AddFilmExhibition(FilmExhibition filmExhibition)
        {
            throw new NotImplementedException();
        }

        public void AddFilms(Films film)
        {
            throw new NotImplementedException();
        }

        public void AddItem(Items item)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Items> GetItemsByOrderId()
        {
            throw new NotImplementedException();
        }
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

        public void AddFilmExhibition(FilmExhibition filmExhibition)
        {
            ctx.FilmExhibitions.Add(filmExhibition);
            ctx.SaveChanges();
        }
    }
}