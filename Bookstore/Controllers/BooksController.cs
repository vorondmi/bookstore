using System.Web.Mvc;

namespace Bookstore.Controllers
{
    public class BooksController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }
    }
}