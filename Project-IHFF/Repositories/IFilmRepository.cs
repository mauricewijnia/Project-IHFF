using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_IHFF.Models;

namespace Project_IHFF.Repositories
{
    interface IFilmRepository
    {/*
        IEnumerable<FilmExhibitions> GetAllFilmExhibitions();
        void AddItem(Items item);
        void AddFilmExhibition(FilmExhibitions filmExhibition);
        FilmExhibitions getFilmExhibition(int id);*/
    }

    /*public class InMemoryItemsRepository : IItemsRepository
    {
        public void AddFilmExhibition(FilmExhibitions filmExhibition)
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

        public Items GetItemByName(string name)
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

        public void AddFilmExhibition(FilmExhibitions filmExhibition)
        {
            ctx.FilmExhibitionsSet.Add(filmExhibition);
            ctx.SaveChanges();
        }

        public Items GetItemByName(string name)
        {
            Items item = ctx.Items.SingleOrDefault(x => x.name == name);
            return item;
        }
    }*/
}