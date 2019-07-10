using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        StoreContext context = new StoreContext();

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetCountries()
        {
            var countries = await context.Counties.ToListAsync();
            return View(countries);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}