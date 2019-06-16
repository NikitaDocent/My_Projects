using NLayerApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDL.Interfaces;

namespace WebBL.Infrastructure
{
    public static class LogicDependencyResolver
    {
        static IUnitOfWork UoW;

        static LogicDependencyResolver()
        {
            UoW = new EFUnitOfWork();
        }

        public static IUnitOfWork ResolveUoW()
        {
            return UoW;
        }
    }
}
