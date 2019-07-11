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
    public class SellerController : Controller
    {
        IUnitOfWork context;
        public SellerController(IUnitOfWork context)
        {
            this.context = context;
        }
        #region Sellers
        public ActionResult GetSellers()
        {
            var sellers = context.Sellers.GetAll();
            return View(sellers);
        }

        [HttpGet]
        public ActionResult EditSeller(int id)
        {
            var seller = context.Sellers.Get(id);
            if (seller == null) HttpNotFound();
            SelectList list = new SelectList(context.Countries.GetAll(), "CountryId", "Name");
            ViewBag.list = list;
            SelectList listu = new SelectList(context.Users.GetAll(), "UserId", "FullName");
            ViewBag.userlist = listu;
            return View(seller);
        }

        [HttpPost, ActionName("EditSeller")]
        public ActionResult EditSeller(Seller seller)
        {
            if (ModelState.IsValid)
            {
                context.Sellers.Edit(seller);
                context.SaveChanges();
                return RedirectToAction("GetSellers");
            }
            SelectList list = new SelectList(context.Countries.GetAll(), "CountryId", "Name");
            ViewBag.list = list;

            SelectList listu = new SelectList(context.Users.GetAll(), "UserId", "FullName");
            ViewBag.userlist = listu;
            return View();
        }

        [HttpGet]
        public ActionResult CreateSeller()
        {
            SelectList list = new SelectList(context.Countries.GetAll(), "CountryId", "Name");
            ViewBag.list = list;

            SelectList listu = new SelectList(context.Users.GetAll(), "UserId", "FullName");
            ViewBag.userlist = listu;
            return View();
        }

        [HttpPost, ActionName("CreateSeller")]
        public ActionResult CreateSeller(Seller seller)
        {
            if (ModelState.IsValid)
            {
                context.Sellers.Create(seller);
                context.SaveChanges();
                return RedirectToAction("GetSellers");
            }
            SelectList list = new SelectList(context.Countries.GetAll(), "CountryId", "Name");
            ViewBag.list = list;

            SelectList listu = new SelectList(context.Users.GetAll(), "UserId", "FullName");
            ViewBag.userlist = listu;
            return View();
        }

        [HttpGet]
        public ActionResult DeleteSeller(int id)
        {
            var seller = context.Sellers.Get(id);
            if (seller == null) HttpNotFound();
            context.Sellers.Delete(id);
            context.SaveChanges();
            return RedirectToAction("GetSellers");
        }
        #endregion
    }
}