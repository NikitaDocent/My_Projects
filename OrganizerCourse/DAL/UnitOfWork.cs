using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Repository;
using Entity;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private AccessContext accessContext;

        private ComponentRepository repository;


        public UnitOfWork(string connectionString)
        {
            accessContext = new AccessContext(connectionString);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
        public IRepository<Component> Components
        {
            get
            {
                if (repository == null)
                    repository = new ComponentRepository(accessContext);

                return repository;
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
