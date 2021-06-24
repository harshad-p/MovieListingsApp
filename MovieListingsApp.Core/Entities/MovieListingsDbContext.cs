using MovieListingsApp.Entities;
using System.Data.Common;
using System.Data.Entity;

namespace MovieListingsApp.Core.Entities
{
    public class MovieListingsDbContext : DbContext
    {
        public MovieListingsDbContext(string movieListingsDbCs) : base(movieListingsDbCs)
        {
        }

        public MovieListingsDbContext(DbConnection connection) : base(connection, false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<TblMovieActor>().HasKey(entity => new { entity.MovieId, entity.ActorId });
        }

        public virtual DbSet<TblActor> Actors { get; set; }
        public virtual DbSet<TblMovie> Movies { get; set; }
        public virtual DbSet<TblMovieActor> MovieActors { get; set; }
        public virtual DbSet<TblMovieThumbnail> MovieThumbnails { get; set; }
    }
}