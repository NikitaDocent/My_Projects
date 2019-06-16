using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBL.DTO;
using WebBL.Interfaces;
using WebPL.Model;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        IItemService orderService;
        public HomeController(IItemService serv)
        {
            orderService = serv;
        }
        public ActionResult Index()
        {
            //IEnumerable<UsersDTO> usersDtos = orderService.GetAllUsers();
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UsersDTO, UsersViewModel>()).CreateMapper();
            //var users = mapper.Map<IEnumerable<UsersDTO>, List<UsersViewModel>>(usersDtos);
            //return View(users);
            IEnumerable<ItemDTO> usersDtos = orderService.Get();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ItemDTO, ItemViewModel>()).CreateMapper();
            var users = mapper.Map<IEnumerable<ItemDTO>, List<ItemViewModel>>(usersDtos);
            return View(users);
        }

        protected override void Dispose(bool disposing)
        {
            //orderService.Dispose();
            //base.Dispose(disposing);
        }
    }
}
