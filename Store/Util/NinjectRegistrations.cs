using Ninject.Modules;
using Store.Domain.Interfaces;
using Store.Domain.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}