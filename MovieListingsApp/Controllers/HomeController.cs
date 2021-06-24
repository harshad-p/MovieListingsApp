using MovieListingsApp.Contracts.Services;
using System.Web.Mvc;

namespace MovieListingsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IActorsService _actorsService;

        public HomeController(IActorsService actorsService)
        {
            _actorsService = actorsService;
        }

        public ActionResult Index()
        {
            _actorsService.Test().Wait();
            return View();
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