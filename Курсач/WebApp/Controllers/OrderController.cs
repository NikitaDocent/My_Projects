using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Util;
using WebBL.DTO;
using WebBL.Interfaces;
using WebBL.Services;
using WebPL.Model;

namespace WebApp.Controllers
{
    public class OrderController : ApiController
    {
        IOrderServices orderService;
        public OrderController()
        {
            orderService = UIDependensyResolver<OrderService>.ResolveDependency();
        }

        [System.Web.Http.HttpGet]
        public IEnumerable<OrderDTO> GetOrders()
        {

            return orderService.Get();
        }


        [System.Web.Http.HttpGet]
        public OrderViewModel Get(int id)
        {
            var OrdersDtos = orderService.Get(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
            var Orders = mapper.Map<OrderDTO, OrderViewModel>(OrdersDtos);
            return Orders;
        }

        //// POST api/values
        [System.Web.Http.HttpPost]
        public void Post([FromBody]OrderViewModel u)
        {

            orderService.Add(u.User, u.OrderedItems, u.Address, u.Status);
        }

    }
}
