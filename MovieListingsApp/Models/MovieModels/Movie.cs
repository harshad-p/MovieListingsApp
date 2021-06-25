using System.Collections.Generic;

namespace MovieListingsApp.Models.MovieModels
{
    public class Movie
    {
        public Movie()
        {
            ThumbnailIds = new HashSet<long>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public ICollection<long> ThumbnailIds { get; set; }
    }
}