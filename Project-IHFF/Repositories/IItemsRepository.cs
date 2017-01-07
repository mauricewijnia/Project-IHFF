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
        Items GetItemByName(string name);
    }

    public class InMemoryItemsRepository : IItemsRepository
    {
        public void AddFilmExhibition(Exhibitions filmExhibition)
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

        public void AddFilmExhibition(Exhibitions Exhibition)
        {
            ctx.ExhibitionsSet.Add(Exhibition);
            ctx.SaveChanges();
        }

        public Items GetItemByName(string name)
        {
            Items item = ctx.Items.SingleOrDefault(x => x.name == name);
            return item;
        }
    }
}