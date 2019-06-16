using System;
using System.Collections.Generic;
using BLL.Interface;
using Entity;
using DAL;

namespace BLL
{
    public class ComponentManagment : IManagment<Component>
    {
        public UnitOfWork unitOfWork { get; }

        public ComponentManagment()
        {
            unitOfWork = new UnitOfWork("OrganizerDB");
        }

        public void Insert(Component obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            unitOfWork.Components.Insert(obj);
            SaveChanges();
        }

        public void Update(Component obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            unitOfWork.Components.Update(obj);
            SaveChanges();
        }

        public void Delete(Component obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            unitOfWork.Components.Delete(obj);
            SaveChanges();
        }

        public void Load() => unitOfWork.Components.Load();

        public IEnumerable<Component> Find(Func<Component, bool> predicate) => unitOfWork.Components.Find(predicate);

        public Component GetItem(int id) => unitOfWork.Clients.Get(id);

        public List<Component> GetList()
        {
            return unitOfWork.Components.GetAll();
        }
        public void SaveChanges() => unitOfWork.SaveChanges();
    }
}
