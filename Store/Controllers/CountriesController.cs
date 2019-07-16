using Ninject;
using Store.Domain.Interfaces;
using Store.Domain.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using Store.Domain.UOW;

namespace Store.Controllers
{
    public class CountriesController : Controller
    {
        IUnitOfWork context;
        public CountriesController(IUnitOfWork context)
        {
            this.context = context;
        }

        #region Countries
        public ActionResult GetCountries()
        {
            var countries = context.Countries.GetAll();
            return View(countries);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var country = context.Countries.Get(id);
            if (country == null) HttpNotFound();
            return View(country);
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                context.Countries.Edit(country);
                context.SaveChanges();
                return RedirectToAction("GetCountries");
            }
            return View();
        }

        [Authorize(Roles = "admin")]
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
                context.Countries.Create(country);
                context.SaveChanges();
                return RedirectToAction("GetCountries");
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            context.Countries.Delete(id);
            context.SaveChanges();
            return RedirectToAction("GetCountries");
        }

        #endregion
    }
}