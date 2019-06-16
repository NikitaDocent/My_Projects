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
using WebPL.Model;

namespace WebApp.Controllers
{
    public class ItemController : ApiController
    {
        IMapper UserMapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ItemDTO, ItemViewModel>();
            cfg.CreateMap<ItemViewModel, ItemDTO>();
        }).CreateMapper();
        IItemService orderService;
        public ItemController()
        {
            orderService = UIDependensyResolver<IItemService>.ResolveDependency();
        }

        [System.Web.Http.HttpGet]
        public IEnumerable<ItemDTO> GetItems()
        {

            return orderService.Get();
        }


        [System.Web.Http.HttpGet]
        public ItemViewModel Get(int id)
        {
            var ItemsDtos = orderService.Get(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ItemDTO, ItemViewModel>()).CreateMapper();
            var Items = mapper.Map<ItemDTO, ItemViewModel>(ItemsDtos);
            return Items;
        }

        //// POST api/values
        [System.Web.Http.HttpPost]
        public void Post([FromBody]ItemViewModel u)
        {

            orderService.Add(UserMapper.Map<ItemViewModel, ItemDTO>(u));
        }

    }
}
