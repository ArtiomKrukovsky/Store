using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Store.Domain.Models;
using Store.Domain.Interfaces;
using Ninject;
using Store.Domain.UOW;

namespace Store.Controllers
{
    public class OrderItemController : Controller
    {
        IUnitOfWork context;
        public OrderItemController(IUnitOfWork context)
        {
            this.context = context;
        }

        #region OrderItems
        public ActionResult GetOrderItems()
        {
            var orderitems = context.OrderItems.GetAll();
            return View(orderitems);
        }

        [HttpGet]
        public ActionResult EditOrderItem(int id)
        {
            var orderitem = context.OrderItems.Get(id);
            if (orderitem == null) HttpNotFound();
            SelectList list = new SelectList(context.Orders.GetAll(), "OrderId", "OrderId");
            ViewBag.list = list;

            SelectList listprod = new SelectList(context.Products.GetAll(), "ProductId", "Name");
            ViewBag.listprod = listprod;
            return View(orderitem);
        }

        [HttpPost, ActionName("EditOrderItem")]
        public ActionResult EditOrderItem(OrderItem orderitem)
        {
            if (ModelState.IsValid)
            {
                context.OrderItems.Edit(orderitem);
                context.SaveChanges();
                return RedirectToAction("GetOrderItems");
            }
            SelectList list = new SelectList(context.Orders.GetAll(), "OrderId", "OrderId");
            ViewBag.list = list;

            SelectList listprod = new SelectList(context.Products.GetAll(), "ProductId", "Name");
            ViewBag.listprod = listprod;
            return View();
        }

        [HttpGet]
        public ActionResult CreateOrderItem()
        {
            SelectList list = new SelectList(context.Orders.GetAll(), "OrderId", "OrderId");
            ViewBag.list = list;

            SelectList listprod = new SelectList(context.Products.GetAll(), "ProductId", "Name");
            ViewBag.listprod = listprod;
            return View();
        }

        [HttpPost, ActionName("CreateOrderItem")]
        public ActionResult CreateOrderItem(OrderItem orderitem)
        {
            if (ModelState.IsValid)
            {
                context.OrderItems.Create(orderitem);
                context.SaveChanges();
                return RedirectToAction("GetOrderItems");
            }
            SelectList list = new SelectList(context.Orders.GetAll(), "OrderId", "OrderId");
            ViewBag.list = list;

            SelectList listprod = new SelectList(context.Products.GetAll(), "ProductId", "Name");
            ViewBag.listprod = listprod;
            return View();
        }

        [HttpGet]
        public ActionResult DeleteOrderItem(int id)
        {
            var orderitem = context.OrderItems.Get(id);
            if (orderitem == null) HttpNotFound();
            context.OrderItems.Delete(id);
            context.SaveChanges();
            return RedirectToAction("GetOrderItems");
        }
        #endregion
    }
}