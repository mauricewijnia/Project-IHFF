using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_IHFF.Models;
using System.Web.Security;
using Project_IHFF.Repositories;

namespace Project_IHFF.Repositories
{
    interface IShoppingCartRepository
    {
        void AddOrder(Orders order, Accounts account);
    }
    public class DbShoppingCartRepository : IShoppingCartRepository
    {

        private ModelContainer ctx = new ModelContainer();
        public void AddOrder(Orders order, Accounts account)
        {
            order.personId = account.id;
            ctx.Orders.Add(order);
            ctx.SaveChanges();
        }
    }
}
