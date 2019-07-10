using Store.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class StoreController : Controller
    {
        StoreContext context = new StoreContext();

        #region Countries
        public async Task<ActionResult> GetCountries()
        {
            var countries = await context.Counties.ToListAsync();
            return View(countries);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null) HttpNotFound();
            var country = context.Counties.Find(id);
            if (country == null) HttpNotFound();
            return View(country);
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                context.Entry(country).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("GetCountries");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public ActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                context.Counties.Add(country);
                context.SaveChanges();
                return RedirectToAction("GetCountries");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null) HttpNotFound();
            var country = context.Counties.Find(id);
            if (country == null) HttpNotFound();
            return View(country);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int? id)
        {
            if (id == null) HttpNotFound();
            var country = context.Counties.Find(id);
            if (country == null) HttpNotFound();
            context.Counties.Remove(country);
            context.SaveChanges();
            return RedirectToAction("GetCountries");
        }

        #endregion

        #region Users
        public ActionResult GetUsers()
        {
            var users = context.Users.Include(c => c.Country);
            return View(users.ToList());
        }

        [HttpGet]
        public ActionResult EditUser(int? id)
        {
            if (id == null) HttpNotFound();
            var user = context.Users.Find(id);
            if (user == null) HttpNotFound();
            SelectList list = new SelectList(context.Counties, "CountryId", "Name");
            ViewBag.list = list;
            return View(user);
        }

        [HttpPost, ActionName("EditUser")]
        public ActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("GetUsers");
            }
            SelectList list = new SelectList(context.Counties, "CountryId", "Name");
            ViewBag.list = list;
            return View();
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            SelectList list = new SelectList(context.Counties, "CountryId", "Name");
            ViewBag.list = list;
            return View();
        }

        [HttpPost, ActionName("CreateUser")]
        public ActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction("GetUsers");
            }
            SelectList list = new SelectList(context.Counties, "CountryId", "Name");
            ViewBag.list = list;
            return View();
        }

        [HttpGet]
        public ActionResult DeleteUser(int? id)
        {
            if (id == null) HttpNotFound();
            var user = context.Users.Find(id);
            if (user == null) HttpNotFound();
            context.Users.Remove(user);
            context.SaveChanges();
            return RedirectToAction("GetUsers");
        }
        #endregion

        #region Sellers
        public ActionResult GetSellers()
        {
            var sellers = context.Sellers.Include(c => c.Country).Include(c => c.User);
            return View(sellers.ToList());
        }

        [HttpGet]
        public ActionResult EditSeller(int? id)
        {
            if (id == null) HttpNotFound();
            var seller = context.Sellers.Find(id);
            if (seller == null) HttpNotFound();
            SelectList list = new SelectList(context.Counties, "CountryId", "Name");
            ViewBag.list = list;
            SelectList listu = new SelectList(context.Users, "UserId", "FullName");
            ViewBag.userlist = listu;
            return View(seller);
        }

        [HttpPost, ActionName("EditSeller")]
        public ActionResult EditSeller(Seller seller)
        {
            if (ModelState.IsValid)
            {
                context.Entry(seller).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("GetSellers");
            }
            SelectList list = new SelectList(context.Counties, "CountryId", "Name");
            ViewBag.list = list;

            SelectList listu = new SelectList(context.Users, "UserId", "FullName");
            ViewBag.userlist = listu;
            return View();
        }

        [HttpGet]
        public ActionResult CreateSeller()
        {
            SelectList list = new SelectList(context.Counties, "CountryId", "Name");
            ViewBag.list = list;

            SelectList listu = new SelectList(context.Users, "UserId", "FullName");
            ViewBag.userlist = listu;
            return View();
        }

        [HttpPost, ActionName("CreateSeller")]
        public ActionResult CreateSeller(Seller seller)
        {
            if (ModelState.IsValid)
            {
                context.Sellers.Add(seller);
                context.SaveChanges();
                return RedirectToAction("GetSellers");
            }
            SelectList list = new SelectList(context.Counties, "CountryId", "Name");
            ViewBag.list = list;

            SelectList listu = new SelectList(context.Users, "UserId", "FullName");
            ViewBag.userlist = listu;
            return View();
        }

        [HttpGet]
        public ActionResult DeleteSeller(int? id)
        {
            if (id == null) HttpNotFound();
            var seller = context.Sellers.Find(id);
            if (seller == null) HttpNotFound();
            context.Sellers.Remove(seller);
            context.SaveChanges();
            return RedirectToAction("GetSellers");
        }
        #endregion

        #region Products
        public ActionResult GetProducts()
        {
            var products = context.Products.Include(c => c.Seller);
            return View(products.ToList());
        }

        [HttpGet]
        public ActionResult EditProduct(int? id)
        {
            if (id == null) HttpNotFound();
            var product = context.Products.Find(id);
            if (product == null) HttpNotFound();
            SelectList list = new SelectList(context.Sellers, "SellerId", "Name");
            ViewBag.list = list;
            return View(product);
        }

        [HttpPost, ActionName("EditProduct")]
        public ActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("GetProducts");
            }
            SelectList list = new SelectList(context.Sellers, "SellerId", "Name");
            ViewBag.list = list;
            return View();
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            SelectList list = new SelectList(context.Sellers, "SellerId", "Name");
            ViewBag.list = list;
            return View();
        }

        [HttpPost, ActionName("CreateProduct")]
        public ActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("GetProducts");
            }
            SelectList list = new SelectList(context.Sellers, "SellerId", "Name");
            ViewBag.list = list;
            return View();
        }

        [HttpGet]
        public ActionResult DeleteProduct(int? id)
        {
            if (id == null) HttpNotFound();
            var product = context.Products.Find(id);
            if (product == null) HttpNotFound();
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("GetProducts");
        }
        #endregion

        #region Orders
        public ActionResult GetOrders()
        {
            var orders = context.Orders.Include(c => c.User);
            return View(orders.ToList());
        }

        [HttpGet]
        public ActionResult EditOrder(int? id)
        {
            if (id == null) HttpNotFound();
            var order = context.Orders.Find(id);
            if (order == null) HttpNotFound();
            SelectList list = new SelectList(context.Users, "UserId", "FullName");
            ViewBag.list = list;
            return View(order);
        }

        [HttpPost, ActionName("EditOrder")]
        public ActionResult EditOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                context.Entry(order).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("GetOrders");
            }
            SelectList list = new SelectList(context.Users, "UserId", "FullName");
            ViewBag.list = list;
            return View();
        }

        [HttpGet]
        public ActionResult CreateOrder()
        {
            SelectList list = new SelectList(context.Users, "UserId", "FullName");
            ViewBag.list = list;
            return View();
        }

        [HttpPost, ActionName("CreateOrder")]
        public ActionResult CreateOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                context.Orders.Add(order);
                context.SaveChanges();
                return RedirectToAction("GetOrders");
            }
            SelectList list = new SelectList(context.Users, "UserId", "FullName");
            ViewBag.list = list;
            return View();
        }

        [HttpGet]
        public ActionResult DeleteOrder(int? id)
        {
            if (id == null) HttpNotFound();
            var order = context.Orders.Find(id);
            if (order == null) HttpNotFound();
            context.Orders.Remove(order);
            context.SaveChanges();
            return RedirectToAction("GetOrders");
        }
        #endregion

        #region OrderItems
        public ActionResult GetOrderItems()
        {
            var orderitems = context.OrderItems.Include(c => c.Order).Include(c=>c.Product);
            return View(orderitems.ToList());
        }

        [HttpGet]
        public ActionResult EditOrderItem(int? id)
        {
            if (id == null) HttpNotFound();
            var orderitem = context.OrderItems.Find(id);
            if (orderitem == null) HttpNotFound();
            SelectList list = new SelectList(context.Orders, "OrderId", "OrderId");
            ViewBag.list = list;

            SelectList listprod = new SelectList(context.Products, "ProductId", "Name");
            ViewBag.listprod = listprod;
            return View(orderitem);
        }

        [HttpPost, ActionName("EditOrderItem")]
        public ActionResult EditOrderItem(OrderItem orderitem)
        {
            if (ModelState.IsValid)
            {
                context.Entry(orderitem).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("GetOrderItems");
            }
            SelectList list = new SelectList(context.Orders, "OrderId", "OrderId");
            ViewBag.list = list;

            SelectList listprod = new SelectList(context.Products, "ProductId", "Name");
            ViewBag.listprod = listprod;
            return View();
        }

        [HttpGet]
        public ActionResult CreateOrderItem()
        {
            SelectList list = new SelectList(context.Orders, "OrderId", "OrderId");
            ViewBag.list = list;

            SelectList listprod = new SelectList(context.Products, "ProductId", "Name");
            ViewBag.listprod = listprod;
            return View();
        }

        [HttpPost, ActionName("CreateOrderItem")]
        public ActionResult CreateOrderItem(OrderItem orderitem)
        {
            if (ModelState.IsValid)
            {
                context.OrderItems.Add(orderitem);
                context.SaveChanges();
                return RedirectToAction("GetOrderItems");
            }
            SelectList list = new SelectList(context.Orders, "OrderId", "OrderId");
            ViewBag.list = list;

            SelectList listprod = new SelectList(context.Products, "ProductId", "Name");
            ViewBag.listprod = listprod;
            return View();
        }

        [HttpGet]
        public ActionResult DeleteOrderItem(int? id)
        {
            if (id == null) HttpNotFound();
            var orderitem = context.OrderItems.Find(id);
            if (orderitem == null) HttpNotFound();
            context.OrderItems.Remove(orderitem);
            context.SaveChanges();
            return RedirectToAction("GetOrderItems");
        }
        #endregion
    }
}