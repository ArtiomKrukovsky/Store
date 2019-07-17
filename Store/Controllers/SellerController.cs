using Ninject;
using Store.Domain.Interfaces;
using Store.Domain.Models;
using Store.Domain.UOW;
using Store.Models;
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
        public ActionResult GetSellers(int? country, int? user_code)
        {
            var sellers = context.Sellers.GetAll();
            if (country!=null && country!=0)
            {
                sellers = sellers.Where(s => s.CountryId == country);
            }

            if (user_code != null && user_code != 0)
            {
                sellers = sellers.Where(s => s.UserId == user_code);
            }

            List<Country> countries = context.Countries.GetAll().ToList();
            countries.Insert(0, new Country { CountryId = 0, Name = "Все" });

            List<User> users = context.Users.GetAll().ToList();
            users.Insert(0, new User { UserId = 0, FullName = "Все" });

            SellerFilterViewModel sellerFilter = new SellerFilterViewModel
            {
                Sellers = sellers.ToList(),
                Country = new SelectList(countries, "CountryId", "Name"),
                User = new SelectList(users, "UserId", "FullName")
            };

            return View(sellerFilter);
        }

        [Authorize(Roles = "admin, seller")]
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
        [Authorize(Roles = "admin, seller")]
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
        [Authorize(Roles = "admin, seller")]
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