using Store.Domain.Repositories;
using Store.Domain.Models;

namespace Store.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        GenericRepository<Country> Countries {get;}
        GenericRepository<User> Users { get; }
        GenericRepository<Seller> Sellers { get; }
        GenericRepository<Product> Products { get; }
        GenericRepository<Order> Orders { get; }
        GenericRepository<OrderItem> OrderItems { get; }

        void SaveChanges();
    }
}
