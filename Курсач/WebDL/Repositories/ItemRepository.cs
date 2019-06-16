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
    public class ItemRepository : IRepository<Item>
    {
        private EF.UsersContext db;

        public ItemRepository(EF.UsersContext context)
        {
            this.db = context;
        }

        public IEnumerable<Item> GetAll()
        {
            return db.Item;
        }

        public Item Get(int id)
        {
            return db.Item.Find(id);
        }

        public void Create(Item book)
        {
            db.Item.Add(book);
        }

        public void Update(Item book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Item> Find(Func<Item, Boolean> predicate)
        {
            return db.Item.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Item book = db.Item.Find(id);
            if (book != null)
                db.Item.Remove(book);
        }
    }
}

