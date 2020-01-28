using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EliteDangerous_test.Models;

namespace EliteDangerous_test.Controllers
{
    public class HomeController : Controller
    {
        private EliteDangerousEntities db = new EliteDangerousEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Application description page.";

            ViewAbout details = new ViewAbout();

            details.CategoryCount = db.Category.Count();
            details.CommoditiesCount = db.Commodities.Count();
            details.ListingsCount = db.listings.Count();
            details.StationsCount = db.Station.Count();
            details.SystemsCount = db.Systems.Count();


            return View(details);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";

            return View();
        }
    }
}