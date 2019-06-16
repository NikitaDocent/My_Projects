using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebBL.DTO;
using WebBL.Interfaces;
using WebPL.Model;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using WebApp.Util;
using System.Web;

namespace WebApp.Controllers
{
    
    public class ValuesController : ApiController
    {
        static readonly Dictionary<Guid, UsersViewModel> updates = new Dictionary<Guid, UsersViewModel>();
        // GET api/values
        IUserService orderService;
        public ValuesController(IUserService serv)
        {
            orderService = serv;
        }
        public ValuesController()
        {
            orderService = UIDependensyResolver<IUserService>.ResolveDependency();
        }

        [System.Web.Http.HttpGet]
        public IEnumerable<UsersDTO> GetUsers()
        {
           
            return orderService.GetAllUsers();
        }
       
       
        [System.Web.Http.HttpGet]
        public UsersViewModel Get(int id)
        {
            var usersDtos = orderService.GetUser(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UsersDTO, UsersViewModel>()).CreateMapper();
            var users = mapper.Map<UsersDTO, UsersViewModel>(usersDtos);
            return users;
        }

        //// POST api/values
        [System.Web.Http.HttpPost]
        public void Post([FromBody]UsersViewModel u)
        {
            
            orderService.Register(u.Name, u.Surname, u.Email, u.TelNumb, u.Password);
        }
        

    }
}
