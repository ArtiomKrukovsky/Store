using Store.Domain.Repositories;
using Store.Domain.Models;

namespace Store.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Country> Countries {get;}
        IRepository<User> Users { get; }
        IRepository<Seller> Sellers { get; }
        IRepository<Product> Products { get; }
        IRepository<Order> Orders { get; }
        IRepository<OrderItem> OrderItems { get; }
        IRepository<Role> Roles { get; }

        void SaveChanges();
    }
}
