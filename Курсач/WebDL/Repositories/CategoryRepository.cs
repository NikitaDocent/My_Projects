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
    public class CategoryRepository : IRepository<Category>
    {
        private EF.UsersContext db;

        public CategoryRepository(EF.UsersContext context)
        {
            this.db = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Category;
        }

        public Category Get(int id)
        {
            return db.Category.Find(id);
        }

        public void Create(Category book)
        {
            db.Category.Add(book);
        }

        public void Update(Category book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Category> Find(Func<Category, Boolean> predicate)
        {
            return db.Category.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Category book = db.Category.Find(id);
            if (book != null)
                db.Category.Remove(book);
        }
    }
}

