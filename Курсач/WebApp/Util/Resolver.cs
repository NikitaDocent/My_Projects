using NLayerApp.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBL.Interfaces;
using WebBL.Services;

namespace WebApp.Util
{
    public static class UIDependensyResolver<T>
    {
        public static dynamic ResolveDependency()
        {
            if (typeof(T) == typeof(IUserService))
                return new UserService();
            if (typeof(T) == typeof(ICategoryService))
                return new CategoryService();
            if (typeof(T) == typeof(IItemService))
                return new ItemService();
            if (typeof(T) == typeof(IOrderServices))
                return new OrderService();

            else return null;
        }
    }
}