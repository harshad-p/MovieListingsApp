using MovieListingsApp.Contracts.Services;
using System.Web.Mvc;

namespace MovieListingsApp.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _actorsService;

        public ActorsController(IActorsService actorsService)
        {
            _actorsService = actorsService;
        }

        public ActionResult Index()
        {
            _actorsService.Test().Wait();
            return View();
        }

    }
}