﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using NLayerApp.DAL.Repositories;
using WebDL.Interfaces;
using WebDL.Repositories;

namespace WebBL.Infrastructure
{
    

    namespace NLayerApp.BLL.Infrastructure
    {
        public class ServiceModule : NinjectModule
        {
            private string connectionString;
            public ServiceModule(string connection)
            {
                connectionString = connection;
            }
            public override void Load()
            {
                Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
            }
        }
    }
}
