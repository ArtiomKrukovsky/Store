using Ninject;
using Store.Domain.Interfaces;
using Store.Domain.Models;
using Store.Domain.UOW;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class OrderController : Controller
    {
        IUnitOfWork context;
        public OrderController(IUnitOfWork context)
        {
            this.context = context;
        }

        #region Orders
        public ActionResult GetOrders()
        {
            var orders = context.Orders.GetAll();
            return View(orders);
        }

        [HttpGet]
        public ActionResult EditOrder(int id)
        {
            var order = context.Orders.Get(id);
            if (order == null) HttpNotFound();
            SelectList list = new SelectList(context.Users.GetAll(), "UserId", "FullName");
            ViewBag.list = list;
            return View(order);
        }

        [HttpPost, ActionName("EditOrder")]
        public ActionResult EditOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                context.Orders.Edit(order);
                context.SaveChanges();
                return RedirectToAction("GetOrders");
            }
            SelectList list = new SelectList(context.Users.GetAll(), "UserId", "FullName");
            ViewBag.list = list;
            return View();
        }

        [HttpGet]
        public ActionResult CreateOrder()
        {
            SelectList list = new SelectList(context.Users.GetAll(), "UserId", "FullName");
            ViewBag.list = list;
            return View();
        }

        [HttpPost, ActionName("CreateOrder")]
        public ActionResult CreateOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                context.Orders.Create(order);
                context.SaveChanges();
                return RedirectToAction("GetOrders");
            }
            SelectList list = new SelectList(context.Users.GetAll(), "UserId", "FullName");
            ViewBag.list = list;
            return View();
        }

        [HttpGet]
        public ActionResult DeleteOrder(int id)
        {
            var order = context.Orders.Get(id);
            if (order == null) HttpNotFound();
            context.Orders.Delete(id);
            context.SaveChanges();
            return RedirectToAction("GetOrders");
        }
        #endregion
    }
}