namespace Store
{
    using Store.Domain.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

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
        public DbSet<Role> Roles { get; set; }
    }

    public class InitDB: DropCreateDatabaseAlways<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            Role adminrole = new Role {RoleId=1,Name="admin" };
            Role sellerrole = new Role { RoleId = 2, Name = "seller" };
            Role userrole = new Role { RoleId = 3, Name = "user" };
            context.Roles.Add(adminrole); context.Roles.Add(sellerrole); context.Roles.Add(userrole);
            Country county = new Country { CountryId = 375, Name = "Belarus", Continent_Name = "Eurasia" };
            Country county1 = new Country { CountryId = 7, Name = "Russia", Continent_Name = "Eurasia" };
            context.Counties.Add(county); context.Counties.Add(county1);

            User user = new User { UserId = 1, FullName = "Круковский А.Ю.", Email = "artiom@gmail.com", Gender = "муж", Date_of_birthday = new DateTime(2000, 10, 15), Create_At = DateTime.Today, CountryId = county.CountryId, RoleId=adminrole.RoleId, Password="artiom1234" };
            context.Users.Add(user);
            User user_s = new User { UserId = 2, FullName = "Паркунович И.Е.", Email = "myseller@gmail.com", Gender = "муж", Date_of_birthday = new DateTime(1987, 10, 15), Create_At = DateTime.Today, CountryId = county.CountryId, RoleId = sellerrole.RoleId, Password = "seller1234" };
            context.Users.Add(user_s);

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