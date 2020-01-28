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
    public class StationsController : Controller
    {
        private EliteDangerousEntities db = new EliteDangerousEntities();
        const int _Interval = 20;

        // GET: Stations
        public ActionResult Index(int? id)
        {
            if (id == null || !id.HasValue || id < 1) id = 1;

            ViewStationsIndex resultatPage = new ViewStationsIndex();

            resultatPage.Stations= db.Station.Where(m => (m.Id >= id && m.Id < (id + _Interval))).ToList();
            resultatPage.StationCount = db.Systems.Count();

            return View(resultatPage);

        }


        // GET: Stations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station station = db.Station.Find(id);
            if (station == null)
            {
                return HttpNotFound();
            }
            return View(station);
        }

        public ActionResult Search(ViewStationsSearch search)
        {
  
            return View(search);
        }

        [HttpPost]
        [ActionName("Search")]
        public ActionResult SearchPost(ViewStationsSearch res)
        {
            if (ControllerContext != null && ControllerContext.HttpContext.Request.Form["critere"] != null)
            {

                ViewStationsSearch search = new ViewStationsSearch();

                search.SearchCritere = ControllerContext.HttpContext.Request.Form["critere"].ToString();

                search.Stations = db.Station.Where(s => s.name.Contains(search.SearchCritere)).Take(20).ToList();
                return Search(search);
            }

            return Search(null);
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
