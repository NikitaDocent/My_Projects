using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Repository;
using DAL.Interface;
using DesignAgency;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private Entity accessContext;
        private ServiceRepository serviceRepository;
        private ClientsRepository clientsRepository;
        public UnitOfWork(string connectionString)
        {
            accessContext = new Entity(connectionString);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public IRepository<DesignService> Service
        {
            get
            {
                if (serviceRepository == null)
                    serviceRepository = new ServiceRepository(accessContext);

                return serviceRepository;
            }
        }

        public IRepository<Client> Clients
        {
            get
            {
                if (clientsRepository == null)
                    clientsRepository = new ClientsRepository(accessContext);

                return clientsRepository;
            }
        }

        public void SaveChanges()
        {
            accessContext.SaveChanges();
        }

        #region IDisposable Support


        private bool disposedValue = false; // Для определения избыточных вызовов
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    accessContext.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}

