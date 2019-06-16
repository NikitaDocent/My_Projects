///using Ninject.Modules;
using Ninject.Modules;
using NLayerApp.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBL.Interfaces;
using WebBL.Services;


namespace WebApp.Util
{
    public class OrderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderServices>().To<OrderService>();
            Bind<ICategoryService>().To<CategoryService>();
            Bind<IItemService>().To<ItemService>();
            Bind<IUserService>().To<UserService>();
        }
    }
}