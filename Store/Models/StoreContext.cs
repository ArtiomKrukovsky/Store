namespace Store
{
    using Store.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class StoreContext : DbContext
    {

        public StoreContext()
            : base("name=StoreContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Country> Counties { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }

    public class InitDB: DropCreateDatabaseAlways<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            Country county = new Country { CountryId = 375, Name = "Belarus", Continent_Name = "Eurasia" };
            Country county1 = new Country { CountryId = 7, Name = "Russia", Continent_Name = "Eurasia" };
            context.Counties.Add(county); context.Counties.Add(county1);

            User user = new User { UserId = 1, FullName = "Круковский А.Ю.", Email = "artiom@gmail.com", Gender = "муж", Date_of_birthday = new DateTime(2000, 10, 15), Create_At = DateTime.Today, CountryId = county.CountryId };
            context.Users.Add(user);
            Seller seller = new Seller { SellerId = 1, Name = "Krim", CountryId = county1.CountryId, Create_At = DateTime.Today, UserId = user.UserId };
            context.Sellers.Add(seller);
            Product product = new Product { ProductId = 1, Name = "Car", SellerId = seller.SellerId, Price = 5000, Status = "Разрабатывается", Create_At = DateTime.Today };
            context.Products.Add(product);
            Order order = new Order { OrderId = 1, Status = "created", Create_At = DateTime.Today, UserId = user.UserId };
            context.Orders.Add(order);
            OrderItem orderItem = new OrderItem { OrderItemId = 1, OrderId = order.OrderId, ProductId = product.ProductId, Quantity = 1 };
            context.OrderItems.Add(orderItem);
            base.Seed(context);
        }
    }

}