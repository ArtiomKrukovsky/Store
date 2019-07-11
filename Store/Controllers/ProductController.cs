using Ninject;
using Store.Domain.Interfaces;
using Store.Domain.Models;
using Store.Domain.UOW;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        IUnitOfWork context;
        public ProductController(IUnitOfWork context)
        {
            this.context = context;
        }

        #region Products
        public ActionResult GetProducts()
        {
            var products = context.Products.GetAll();
            return View(products);
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var product = context.Products.Get(id);
            if (product == null) HttpNotFound();
            SelectList list = new SelectList(context.Sellers.GetAll(), "SellerId", "Name");
            ViewBag.list = list;
            return View(product);
        }

        [HttpPost, ActionName("EditProduct")]
        public ActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Edit(product);
                context.SaveChanges();
                return RedirectToAction("GetProducts");
            }
            SelectList list = new SelectList(context.Sellers.GetAll(), "SellerId", "Name");
            ViewBag.list = list;
            return View();
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            SelectList list = new SelectList(context.Sellers.GetAll(), "SellerId", "Name");
            ViewBag.list = list;
            return View();
        }

        [HttpPost, ActionName("CreateProduct")]
        public ActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Create(product);
                context.SaveChanges();
                return RedirectToAction("GetProducts");
            }
            SelectList list = new SelectList(context.Sellers.GetAll(), "SellerId", "Name");
            ViewBag.list = list;
            return View();
        }

        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            var product = context.Products.Get(id);
            if (product == null) HttpNotFound();
            context.Products.Delete(id);
            context.SaveChanges();
            return RedirectToAction("GetProducts");
        }
        #endregion
    }
}