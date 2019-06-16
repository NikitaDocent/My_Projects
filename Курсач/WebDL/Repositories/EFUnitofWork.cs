using System;
using TestApp;
using WebDL;
using WebDL.Repositories;
using WebDL.EF;
using WebDL.Interfaces;
using System.Data.Entity.Validation;
using System.Windows.Forms;

namespace NLayerApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private WebDL.EF.UsersContext db;
        private UsersRepository usersRepository;
        private OrderRepository orderRepository;
        private ItemRepository itemRepository;
        private CategoryRepository categoryRepository;

        public EFUnitOfWork()
        {
            db = new WebDL.EF.UsersContext();
        }
        public IRepository<Users> Users
        {
            get
            {
                if (usersRepository == null)
                    usersRepository = new UsersRepository(db);
                return usersRepository;
            }
        }

        public IRepository<Order> Order
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

        public IRepository<Category> Category
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }

        public IRepository<Item> Item
        {
            get
            {
                if (itemRepository == null)
                    itemRepository = new ItemRepository(db);
                return itemRepository;
            }
        }

        public void Save()
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string message = "";
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    message = "Object: " + validationError.Entry.Entity.ToString();

                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        message = message + err.ErrorMessage + "";
                    }
                }
                MessageBox.Show(message);
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}