using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp;
using WebDL.EF;
using WebDL.Interfaces;
using WebDL.Repositories;

namespace WebDL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private EF.UsersContext db;

        public OrderRepository(EF.UsersContext context)
        {
            this.db = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Order;
        }

        public Order Get(int id)
        {
            return db.Order.Find(id);
        }

        public void Create(Order book)
        {
            db.Order.Add(book);
        }

        public void Update(Order book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Order> Find(Func<Order, Boolean> predicate)
        {
            return db.Order.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Order book = db.Order.Find(id);
            if (book != null)
                db.Order.Remove(book);
        }
    }
}
