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

        public MovieThumbnailsController()
        {
        }

        public async Task<ActionResult> Download(long id)
        {
            var attachment = await _movieThumbnailsService.GetByIdLightAsync(id);
            if (attachment == null || attachment.Content == null)
            {
                return View("NotFound", "Attachment not found.");
            }
            return File(attachment.Content, System.Net.Mime.MediaTypeNames.Application.Octet, attachment.FileName);
        }

    }
}