using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using DesignAgency;

namespace DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<DesignService> Service { get; }
        IRepository<Client> Clients { get; }
        void SaveChanges();
    }
}
