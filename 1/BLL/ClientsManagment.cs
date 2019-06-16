using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DesignAgency;
using AutoMapper;

namespace BLL
{
    public class ClientsManagment : IManagment<Client>
    {
        IMapper MClient = new MapperConfiguration(cfg => cfg.CreateMap<Client, Client>()).CreateMapper();
        private UnitOfWork unitOfWork { get; }

        public ClientsManagment()
        {
            unitOfWork = new UnitOfWork("FirstConnect");
        }

        public void Insert(Client obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            unitOfWork.Clients.Insert(obj);
        }

        public void Update(Client obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            unitOfWork.Clients.Update(obj);
        }

        public void Delete(Client obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            unitOfWork.Clients.Delete(obj);
        }

        public void Load() => unitOfWork.Clients.Load();

        public IEnumerable<Client> Find(Func<Client, bool> predicate) => unitOfWork.Clients.Find(predicate);

        public Client GetItem(int id)
        {
            return unitOfWork.Clients.Get(id);
        }
        public List<Client> GetList()
        {
           return MClient.Map<IEnumerable<Client>, List<Client>>(unitOfWork.Clients.GetAll());
        }
        public void SaveChanges() => unitOfWork.SaveChanges();
    }

}
