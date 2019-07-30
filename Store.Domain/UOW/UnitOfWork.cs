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

        public UnitOfWork(IRepository<Country> repository, IRepository<User> userrepository, IRepository<Role> rolerepository, 
            IRepository<Seller> sellerrepository, IRepository<Product> productrepository, IRepository<Order> orderrepository, 
            IRepository<OrderItem> orderitemrepository)
        {
            countryRepository= repository;
            userRepository = userrepository;
            roleRepository = rolerepository;
            sellerRepository = sellerrepository;
            productRepository = productrepository;
            orderRepository = orderrepository;
            orderitemRepository = orderitemrepository;
        }

        private IRepository<Country> countryRepository;
        private IRepository<User> userRepository;
        private IRepository<Seller> sellerRepository;
        private IRepository<Product> productRepository;
        private IRepository<Order> orderRepository;
        private IRepository<OrderItem> orderitemRepository;
        private IRepository<Role> roleRepository;


        public IRepository<Country> Countries
        {
            get
            {
                return countryRepository;
            }
        }

        public IRepository<Role> Roles
        {
            get
            {
                return roleRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return userRepository;
            }
        }

        public IRepository<Seller> Sellers
        {
            get
            {
                return sellerRepository;
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                return productRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                return orderRepository;
            }
        }

        public IRepository<OrderItem> OrderItems
        {
            get
            {
                return orderitemRepository;
            }
        }

        public void SaveChanges()
        {
            countryRepository.SaveChanges();
            userRepository.SaveChanges();
            roleRepository.SaveChanges(); 
            sellerRepository.SaveChanges();
            productRepository.SaveChanges();
            orderRepository.SaveChanges();
            orderitemRepository.SaveChanges();
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
