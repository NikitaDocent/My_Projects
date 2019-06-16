using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Component> Components { get; }
        void SaveChanges();
    }
}
