using System.Linq;
using System.Net;
using System.Web.Mvc;
using EliteDangerous_test.Models;

namespace EliteDangerous_test.Controllers
{
    public class CategoriesController : Controller
    {
        private EliteDangerousEntities db = new EliteDangerousEntities();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.Category.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
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
