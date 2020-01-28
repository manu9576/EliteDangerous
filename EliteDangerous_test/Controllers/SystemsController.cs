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
    public class SystemsController : Controller
    {
        private EliteDangerousEntities db = new EliteDangerousEntities();
        const int _Interval = 20;


        // GET: Systems
        public ActionResult Index(IEnumerable<Systems> sys)
        {
            if (sys == null) sys = db.Systems.Take(_Interval);

            ViewSystemsIndex resultatPage = new ViewSystemsIndex();

            resultatPage.Systems =sys.ToList();
            resultatPage.SystemCount = sys.Count();

            return View("Index", resultatPage);
        }
         
        public ActionResult SystemsList(IEnumerable<Systems> sys)
        {
           
            return PartialView(sys);
        }

        // GET: Systems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Systems systems = db.Systems.Find(id);
            if (systems == null)
            {
                return HttpNotFound();
            }
            return View(systems);
        }


        [HttpPost]
        [ActionName("Details")]
        public ActionResult DetailsPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Systems systems = db.Systems.Find(id);

            if (ControllerContext != null && ControllerContext.HttpContext.Request.Form["nearly"] != null)
            {

                return Index(systems.GetSystems(20));

            } 

            return Details(id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult Search(ViewSystemsSearch search)
        {

            return View(search);
        }

        [HttpPost]
        [ActionName("Search")]
        public ActionResult SearchPost(ViewSystemsSearch res)
        {
            if (ControllerContext != null && ControllerContext.HttpContext.Request.Form["critere"] != null)
            {

                ViewSystemsSearch search = new ViewSystemsSearch();

                search.SearchCritere = ControllerContext.HttpContext.Request.Form["critere"].ToString();

                search.Systems = db.Systems.Where(s => s.name.Contains(search.SearchCritere)).Take(20).ToList();
                return Search(search);
            }

            return Search(null);
        }

        public ActionResult SystemsList(List<Systems> systems)
        {
            return PartialView(systems);
        }
    }
}
