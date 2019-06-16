using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface;
using Entity;
using System.Data.Entity;

namespace DAL.Repository
{
    public class ComponentRepository : IRepository<Component>
    {
        private AccessContext accessContext;

        public ComponentRepository(AccessContext p_accessContext)
        {
            accessContext = p_accessContext;
        }

        public IEnumerable<Component> Find(Func<Component, bool> predicate)
        {
            return accessContext.Components.Where(predicate).ToList();
        }

        public Component Get(int id)
        {
            return accessContext.Components.Find(id);
        }

        public IEnumerable<Component> GetAll()
        {
            return accessContext.Components.Local.ToBindingList();
        }

        public void Insert(Component obj)
        {
            accessContext.Components.Add(obj);
            accessContext.Entry(obj).State = EntityState.Added;
        }
        public void Update(Component obj)
        {
            accessContext.Entry<Component>(obj).State = EntityState.Modified;
        }


        public void Delete(Component obj)
        {
            accessContext.Components.Remove(obj);
            accessContext.Entry<Component>(obj).State = EntityState.Deleted;
        }

        public void Load()
        {
            accessContext.Components.Load();
        }

    }
}
