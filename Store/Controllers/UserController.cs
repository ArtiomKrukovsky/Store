using System.Web.Mvc;
using Store.Domain.Models;
using Store.Domain.Interfaces;
using Store.Domain.UOW;
using Ninject;
using System;
using System.Linq;
using Store.Models;
using System.Collections.Generic;

namespace Store.Controllers
{
    public class UserController : Controller
    {

        IUnitOfWork context;
        public UserController(IUnitOfWork context)
        {
            this.context = context;
        }

        #region Users
        public ActionResult GetUsers(string fullname, string email, string create_at)
        {
            var users = context.Users.GetAll();
            if (!String.IsNullOrEmpty(fullname) && !fullname.Equals("Все"))
            {
                users = users.Where(u => u.FullName == fullname);
            }

            if (!String.IsNullOrEmpty(email) && !email.Equals("Все"))
            {
                users = users.Where(u => u.Email == email);
            }

            if (!String.IsNullOrEmpty(create_at) && !create_at.Equals("Все"))
            {
                users = users.Where(u => u.Create_At == Convert.ToDateTime(create_at));
            }

            UserFilterViewModel userFilter = new UserFilterViewModel
            {
                Users = users.ToList(),
                FullName = new SelectList(new List<string>() {"Все","Круковский А.Ю.", "Мурканич А.Ю.", "Паркунович И.Е.", "Миркович А.Т." }),
                Email= new SelectList(new List<string>() { "Все", "artiom@gmail.com", "myseller@gmail.com", "mirkovich@gmail.com", "myrkach@gmail.com" }),
                Create_At = new SelectList(new List<string>() {"Все", (new DateTime(2019, 07, 16)).ToString() })
            };

            return View(userFilter);
        }

        [Authorize(Roles="admin")]
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var user = context.Users.Get(id);
            if (user == null) HttpNotFound();
            SelectList list = new SelectList(context.Countries.GetAll(), "CountryId", "Name");
            ViewBag.list = list;
            return View(user);
        }

        [HttpPost, ActionName("EditUser")]
        public ActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                context.Users.Edit(user);
                context.SaveChanges();
                return RedirectToAction("GetUsers");
            }
            SelectList list = new SelectList(context.Countries.GetAll(), "CountryId", "Name");
            ViewBag.list = list;
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult CreateUser()
        {
            SelectList list = new SelectList(context.Countries.GetAll(), "CountryId", "Name");
            ViewBag.list = list;
            return View();
        }

        [HttpPost, ActionName("CreateUser")]
        public ActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                context.Users.Create(user);
                context.SaveChanges();
                return RedirectToAction("GetUsers");
            }
            SelectList list = new SelectList(context.Countries.GetAll(), "CountryId", "Name");
            ViewBag.list = list;
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            var user = context.Users.Get(id);
            if (user == null) HttpNotFound();
            context.Users.Delete(id);
            context.SaveChanges();
            return RedirectToAction("GetUsers");
        }
        #endregion
    }
}