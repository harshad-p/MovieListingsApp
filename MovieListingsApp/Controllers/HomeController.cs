using MovieListingsApp.Contracts.FormModelGenerators;
using MovieListingsApp.Contracts.Services;
using MovieListingsApp.Contracts.ViewModelGenerators;
using MovieListingsApp.Models.MovieModels;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MovieListingsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieViewModelGenerators _movieViewModelGenerators;
        private readonly IMovieFormModelGenerators _movieFormModelGenerators;
        private readonly IMoviesService _moviesService;

        public HomeController(IMovieViewModelGenerators movieViewModelGenerators,
                              IMovieFormModelGenerators movieFormModelGenerators,
                              IMoviesService moviesService)
        {
            _movieViewModelGenerators = movieViewModelGenerators;
            _movieFormModelGenerators = movieFormModelGenerators;
            _moviesService = moviesService;
        }

        public async Task<ActionResult> Index()
        {
            var viewModel = await _movieViewModelGenerators.GetIndexViewModelAsync();
            if(viewModel == null)
            {
                return View("Error", "_Layout", "Cannot View Movie Listings at the moment.");
            }

            return View(viewModel);
        }

        public async Task<ActionResult> Details(int id)
        {
            var viewModel = await _movieViewModelGenerators.GetDetailsViewModelAsync(id);
            if (viewModel == null)
            {
                return View("Error", "_Layout", "Cannot View Movie Details at the moment.");
            }

            return View(viewModel);
        }

        public async Task<ActionResult> Create()
        {
            var formModel = await _movieFormModelGenerators.GetCreateFormModelAsync();
            if (formModel == null)
            {
                return View("Error", "_Layout", "Cannot Create Movie Listing at the moment.");
            }
            ViewBag.actors = formModel.Actors;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateViewModel createViewModel)
        {
            var formModel = await _movieFormModelGenerators.GetCreateFormModelAsync();
            if (formModel == null)
            {
                return View("Error", "_Layout", "Cannot Create Movie Listing at the moment.");
            }
            ViewBag.actors = formModel.Actors;

            if (!ModelState.IsValid)
            {
                return View(createViewModel);
            }

            var movieId = await _moviesService.CreateAsync(createViewModel);
            if(movieId == -1)
            {
                return View("Error", "_Layout", "Cannot Create Movie Listing at the moment.");
            }

            return RedirectToAction("Details", new { id = movieId });
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