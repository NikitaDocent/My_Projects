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
    public class ServicesManagment : IManagment<DesignService>
    {
        IMapper MService = new MapperConfiguration(cfg => cfg.CreateMap<DesignService, DesignService>()).CreateMapper();
        private UnitOfWork unitOfWork { get; }

        public ServicesManagment()
        {
            unitOfWork = new UnitOfWork("FirstConnect");
        }

        public void Insert(DesignService obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            unitOfWork.Service.Insert(obj);
        }

        public void Update(DesignService obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            unitOfWork.Service.Update(obj);
        }

        public void Delete(DesignService obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            unitOfWork.Service.Delete(obj);
        }

        public void Load() => unitOfWork.Service.Load();

        public IEnumerable<DesignService> Find(Func<DesignService, bool> predicate) => unitOfWork.Service.Find(predicate);

        public DesignService GetItem(int id)
        {
            return unitOfWork.Service.Get(id);
        }
        public List<DesignService> GetList()
        {
            return MService.Map<IEnumerable<DesignService>, List<DesignService>>(unitOfWork.Service.GetAll());
        }
        public void SaveChanges() => unitOfWork.SaveChanges();
    }
}
