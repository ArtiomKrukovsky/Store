using Store.Domain.Interfaces;
using Store.Domain.Repositories;
using Store.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.UOW
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private StoreContext context = new StoreContext();

        private GenericRepository<Country> countryRepository;
        private GenericRepository<User> userRepository;
        private GenericRepository<Seller> sellerRepository;
        private GenericRepository<Product> productRepository;
        private GenericRepository<Order> orderRepository;
        private GenericRepository<OrderItem> orderitemRepository;
        private GenericRepository<Role> roleRepository;


        public GenericRepository<Country> Countries
        {
            get
            {
                if (countryRepository == null)
                    countryRepository = new GenericRepository<Country>(context);
                return countryRepository;
            }
        }

        public GenericRepository<Role> Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new GenericRepository<Role>(context);
                return roleRepository;
            }
        }

        public GenericRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new GenericRepository<User>(context);
                return userRepository;
            }
        }

        public GenericRepository<Seller> Sellers
        {
            get
            {
                if (sellerRepository == null)
                    sellerRepository = new GenericRepository<Seller>(context);
                return sellerRepository;
            }
        }

        public GenericRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new GenericRepository<Product>(context);
                return productRepository;
            }
        }

        public GenericRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new GenericRepository<Order>(context);
                return orderRepository;
            }
        }

        public GenericRepository<OrderItem> OrderItems
        {
            get
            {
                if (orderitemRepository == null)
                    orderitemRepository = new GenericRepository<OrderItem>(context);
                return orderitemRepository;
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
