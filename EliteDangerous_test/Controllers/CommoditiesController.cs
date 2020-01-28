using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EliteDangerous_test.Models;

namespace EliteDangerous_test.Controllers
{
    public class CommoditiesController : Controller
    {
        private EliteDangerousEntities db = new EliteDangerousEntities();

        // GET: Commodities
        public ActionResult Index()
        {
            var commodities = db.Commodities.Include(c => c.Category);
            return View(commodities.ToList());
        }

        // GET: Commodities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commodities commodities = db.Commodities.Find(id);
            if (commodities == null)
            {
                return HttpNotFound();
            }
            return View(commodities);
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
