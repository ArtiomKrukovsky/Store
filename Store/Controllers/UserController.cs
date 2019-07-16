using System.Web.Mvc;
using Store.Domain.Models;
using Store.Domain.Interfaces;
using Store.Domain.UOW;
using Ninject;

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
        public ActionResult GetUsers()
        {
            var users = context.Users.GetAll();
            return View(users);
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