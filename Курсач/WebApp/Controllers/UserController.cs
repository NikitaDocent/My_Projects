using AutoMapper;
using NLayerApp.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Windows.Forms;
using WebApp.Util;
using WebBL.DTO;
using WebBL.Interfaces;
using WebPL.Model;

namespace WebApp.Controllers
{
    public class UserController : ApiController
    {

        IUserService orderService;
        public UserController()
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
