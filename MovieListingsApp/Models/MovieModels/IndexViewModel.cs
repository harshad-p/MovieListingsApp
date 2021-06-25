using System.Collections.Generic;

namespace MovieListingsApp.Models.MovieModels
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            Movies = new HashSet<Movie>();
        }

        public bool CanCreate { get; set; }
        public ICollection<Movie> Movies { get; set; }

    }
}