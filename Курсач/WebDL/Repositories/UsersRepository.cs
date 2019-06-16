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
    public class UsersRepository : IRepository<Users>
    {
        private EF.UsersContext db;

        public UsersRepository(EF.UsersContext context)
        {
            this.db = context;
        }

        public IEnumerable<Users> GetAll()
        {
            return db.Users;
        }

        public Users Get(int id)
        {
            return db.Users.Find(id);
        }

        public void Create(Users item)
        {
            db.Users.Add(item);
        }

        public void Update(Users book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Users> Find(Func<Users, Boolean> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Users book = db.Users.Find(id);
            if (book != null)
                db.Users.Remove(book);
        }
    }
}
