using MovieListingsApp.Contracts.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TicketingApp.Controllers
{
    public class MovieThumbnailsController : Controller
    {
        private readonly IMovieThumbnailsService _movieThumbnailsService;

        public MovieThumbnailsController(IMovieThumbnailsService movieThumbnailsService)
        {
            _movieThumbnailsService = movieThumbnailsService;
        }

        public async Task<ActionResult> Download(long id)
        {
            var thumbnail = await _movieThumbnailsService.GetByIdLightAsync(id);
            if (thumbnail == null || thumbnail.Content == null)
            {
                return View("NotFound", "_Layout", $"Attachment [Id: {id}] not found.");
            }
            return File(thumbnail.Content, thumbnail.ContentType, thumbnail.FileName);
        }

    }
}