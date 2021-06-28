using MovieListingsApp.Models.MovieModels.ValidationAttributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MovieListingsApp.Models.MovieModels
{
    public class CreateViewModel
    {
        public CreateViewModel()
        {
            Actors = new List<int>();
            Thumbnails = new List<HttpPostedFileBase>();
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? Year { get; set; }

        [ValidateActors]
        public List<int> Actors { get; set; }

        [ValidateThumbnails]
        public List<HttpPostedFileBase> Thumbnails { get; set; }
    }
}