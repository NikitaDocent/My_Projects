using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp;
using WebBL.DTO;
using WebBL.Infrastructure;
using WebBL.Interfaces;
using WebDL.Interfaces;

namespace WebBL.Services
{
    public class OrderService : IOrderServices
    {
        IUnitOfWork Database { get; set; }
        IMapper UserMapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Order, OrderDTO>();
            cfg.CreateMap<OrderDTO, Order>();
        }).CreateMapper();


        public OrderService()
        {
            Database = LogicDependencyResolver.ResolveUoW();
        }



        public IEnumerable<OrderDTO> Get()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Order>, List<OrderDTO>>(Database.Order.GetAll());
        }
        public void Add(OrderDTO c)
        {
            Database.Order.Create(UserMapper.Map<OrderDTO, Order>(c));
            Database.Save();

        }
        public void Delete(int? id)
        {
            Database.Order.Delete(id.Value);
        }
        public OrderDTO Get(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id заказа", "");
            var Order = Database.Order.Get(id.Value);
            if (Order == null)
                throw new ValidationException("Заказ не найден", "");

            return UserMapper.Map<Order, OrderDTO>(Order);
        }

        public void Dispose()
        {
           /// Database.Dispose();
        }
    }
}
