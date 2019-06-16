using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp;

namespace WebDL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Users> Users { get; }
        IRepository<Order> Order { get; }
        IRepository<Category> Category { get; }
        IRepository<Item> Item { get; }
        void Save();
    }
}
