using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interface;
using DesignAgency;

namespace DAL.Repository
{
    public class ServiceRepository : IRepository<DesignService>
    {
        private Entity accessContext;

        public ServiceRepository(Entity p_accessContext)
        {
            accessContext = p_accessContext;
        }

        public IEnumerable<DesignService> Find(Func<DesignService, bool> predicate)
        {
            return accessContext.DesignService.Where(predicate).ToList();
        }

        public DesignService Get(int id)
        {
            return accessContext.DesignService.Find(id);
        }

        public IEnumerable<DesignService> GetAll()
        {
            return accessContext.DesignService.Local.ToBindingList();
        }

        public void Insert(DesignService obj)
        {
            accessContext.DesignService.Add(obj);
            accessContext.Entry(obj).State = EntityState.Added;
        }

        public void Update(DesignService obj)
        {
            accessContext.Entry<DesignService>(obj).State = EntityState.Modified;
        }

        public void Delete(DesignService obj)
        {
            accessContext.DesignService.Remove(obj);
        }

        public void Load()
        {
            accessContext.DesignService.Load();
        }
    }
}
