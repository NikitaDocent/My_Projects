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
using WebPL.Models;

namespace WebApp.Controllers
{
    public class CategoryController : ApiController
    {
        ICategoryService orderService;
        public CategoryController()
        {
            orderService = UIDependensyResolver<ICategoryService>.ResolveDependency();
        }

        [System.Web.Http.HttpGet]
        public IEnumerable<CategoryDTO> GetCategorys()
        {

            return orderService.Get();
        }


        [System.Web.Http.HttpGet]
        public CategoryViewModel Get(int id)
        {
            var CategorysDtos = orderService.Get(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, CategoryViewModel>()).CreateMapper();
            var Categorys = mapper.Map<CategoryDTO, CategoryViewModel>(CategorysDtos);
            return Categorys;
        }

        //// POST api/values
        [System.Web.Http.HttpPost]
        public void Post([FromBody]CategoryViewModel u)
        {

            orderService.Add(u.Name);
        }

    }
}
