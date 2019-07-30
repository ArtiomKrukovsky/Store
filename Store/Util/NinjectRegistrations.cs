using Ninject.Modules;
using Store.Domain.Interfaces;
using Store.Domain.Models;
using Store.Domain.Repositories;
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
            Bind<IRepository<Country>>().To<GenericRepository<Country>>();
            Bind<IRepository<User>>().To<GenericRepository<User>>();
            Bind<IRepository<Role>>().To<GenericRepository<Role>>();
            Bind<IRepository<Seller>>().To<GenericRepository<Seller>>();
            Bind<IRepository<Product>>().To<GenericRepository<Product>>();
            Bind<IRepository<Order>>().To<GenericRepository<Order>>();
            Bind<IRepository<OrderItem>>().To<GenericRepository<OrderItem>>();
        }
    }
}