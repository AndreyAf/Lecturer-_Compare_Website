using LecturerCompare.Models;
using System.Web.Mvc;
using System.Linq;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {

        public LecDBEntities db = new LecDBEntities();

        public ActionResult Index()
        {

            return View(db.Categories);
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
