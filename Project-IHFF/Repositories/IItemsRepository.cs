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
        void AddFilms(Films film);
    }

    public class InMemoryItemsRepository : IItemsRepository
    {
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

        public void AddFilms(Films film)
        {
            ctx.Items.Add(film);
            ctx.SaveChanges();
        }
    }
}