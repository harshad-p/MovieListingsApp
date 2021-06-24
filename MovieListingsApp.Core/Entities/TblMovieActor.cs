using System.ComponentModel.DataAnnotations;

namespace MovieListingsApp.Entities
{
    public class TblMovieActor
    {
        [Key]
        public int MovieId { get; set; }
        public TblMovie Movie { get; set; }

        [Key]
        public int ActorId { get; set; }
        public TblActor Actor { get; set; }
    }
}