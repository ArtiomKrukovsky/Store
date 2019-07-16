using Store.Domain.Interfaces;
using Store.Domain.Models;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Store.Controllers
{
    public class AccountController : Controller
    {
        IUnitOfWork context;
        public AccountController(IUnitOfWork unitOfWork)
        {
            context = unitOfWork;
        }

        [HttpGet]
        public ActionResult Register()
        {
            SelectList list = new SelectList(context.Countries.GetAll(), "CountryId", "Name");
            ViewBag.list = list;
            return View();
        }

        [HttpPost, ActionName("Register")]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel register)
        {
            if (ModelState.IsValid)
            {
                var user = context.Users.Get(u => u.Email == register.Email);
                if (user.Count() == 0)
                {
                    User newuser = new User { CountryId = register.CountryId, Email = register.Email, Create_At = DateTime.Now, Date_of_birthday = register.Date_of_birthday, FullName = register.FullName, Gender = register.Gender, Password = register.Password, RoleId=3 };
                    context.Users.Create(newuser);
                    context.SaveChanges();
                    user = context.Users.Get(u => u.Email == register.Email);

                    if (user.Count() != 0)
                    {
                        FormsAuthentication.SetAuthCookie(register.Email, true);
                        return RedirectToAction("Index", "Home");
                    }
                }

                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            SelectList list = new SelectList(context.Countries.GetAll(), "CountryId", "Name");
            ViewBag.list = list;
            return View(register);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, ActionName("Login")]
        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var login_user = context.Users.Get(u => u.Email == login.Email);
                var passwork_user = context.Users.Get(u => u.Password == login.Password);
                if (login_user.Count() != 0 && passwork_user.Count() != 0)
                {
                    FormsAuthentication.SetAuthCookie(login.Email, true);
                    return RedirectToAction("Index", "Home");
                }


                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем не существует, попробуйте ещё раз");
                }
            }
        
            return View();
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}