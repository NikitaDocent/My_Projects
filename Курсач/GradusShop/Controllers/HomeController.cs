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
        public ActionResult Index(int? cat, int? pricelow, int? pricehigh, bool? isinstock)
        {
            //IEnumerable<UsersDTO> usersDtos = orderService.GetAllUsers();
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UsersDTO, UsersViewModel>()).CreateMapper();
            //var users = mapper.Map<IEnumerable<UsersDTO>, List<UsersViewModel>>(usersDtos);
            //return View(users);
            IEnumerable<ItemDTO> usersDtos = orderService.Get();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ItemDTO, ItemViewModel>()).CreateMapper();
            var users = mapper.Map<IEnumerable<ItemDTO>, List<ItemViewModel>>(usersDtos);

            if (cat != null)
            {
                List<ItemViewModel> ret = new List<ItemViewModel>();
                foreach (ItemViewModel imv in users)
                {
                    if (imv.Category == cat) ret.Add(imv);
                }
                return View(ret);
            }

            else if (cat != null && pricelow != null)
            {
                List<ItemViewModel> ret = new List<ItemViewModel>();
                foreach (ItemViewModel imv in users)
                {
                    if (imv.Category == cat && imv.Price > pricelow) ret.Add(imv);
                }
                return View(ret);
            }
            else if (cat != null && pricelow != null && pricehigh !=null ) {
                List<ItemViewModel> ret = new List<ItemViewModel>();
                foreach (ItemViewModel imv in users)
                {
                    if (imv.Category == cat && imv.Price > pricelow && imv.Price < pricehigh) ret.Add(imv);
                }
                return View(ret);
            }
            else return View(users); 
        }

        [Authorize]
        public ActionResult ItemPage(int id)
        {
            ItemDTO usersDtos = orderService.Get(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ItemDTO, ItemViewModel>()).CreateMapper();
            var users = mapper.Map<ItemDTO, ItemViewModel>(usersDtos);
            return View(users);
        }

        public ActionResult Cart(string ids)
        {
            if (ids != null)
            {
                List<string> l = ids.Split(',').ToList();
                List<ItemViewModel> cartitems = new List<ItemViewModel>();
                IEnumerable<ItemDTO> usersDtos = orderService.Get();
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ItemDTO, ItemViewModel>()).CreateMapper();
                var users = mapper.Map<IEnumerable<ItemDTO>, List<ItemViewModel>>(usersDtos);
                foreach (var item in users)
                {
                    for (int i = 0; i < l.Count; i = i + 3)
                    {
                        if (item.Id == Convert.ToInt32(l[i]))
                        {
                            cartitems.Add(item);
                        }
                    }
                }

                return View(cartitems);
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            //orderService.Dispose();
            //base.Dispose(disposing);
        }
    }
}
