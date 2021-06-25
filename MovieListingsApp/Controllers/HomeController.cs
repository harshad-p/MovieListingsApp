using MovieListingsApp.Contracts.ViewModelGenerators;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MovieListingsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieViewModelGenerators _movieViewModelGenerators;
        //private readonly IMoviesService _actorsService;

        public HomeController(IMovieViewModelGenerators movieViewModelGenerators)
        {
            _movieViewModelGenerators = movieViewModelGenerators;
        }

        public async Task<ActionResult> Index()
        {
            var viewModel = await _movieViewModelGenerators.GetIndexViewModelAsync();
            if(viewModel == null)
            {
                return View("Error", "Cannot view Movie Listings at the moment.");
            }

            return View(viewModel);
        }

        public async Task<ActionResult> Details(int id)
        {
            var viewModel = await _movieViewModelGenerators.GetDetailsViewModelAsync(id);
            if (viewModel == null)
            {
                return View("Error", "_Layout", "Cannot view Movie Listings at the moment.");
            }

            return View(viewModel);
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