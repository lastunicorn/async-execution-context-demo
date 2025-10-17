using System.Web.Mvc;

namespace DustInTheWind.ExecutionContextDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
