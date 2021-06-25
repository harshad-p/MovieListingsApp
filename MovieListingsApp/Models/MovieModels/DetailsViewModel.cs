using MovieListingsApp.Models.UserPrivileges;
using System.Collections.Generic;

namespace MovieListingsApp.Models.MovieModels
{
    public class DetailsViewModel
    {
        public DetailsViewModel()
        {
            Actors = new HashSet<Actor>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public ICollection<long> ThumbnailIds { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public MovieUserPrivileges MovieUserPrivileges { get; set; }
    }
}