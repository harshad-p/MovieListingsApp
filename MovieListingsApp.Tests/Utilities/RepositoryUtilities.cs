using MovieListingsApp.Core.Contracts.Repositories;
using MovieListingsApp.Infrastructure.Repositories;

namespace MovieListingsApp.Tests.Utilities
{
    class RepositoryUtilities
    {
        internal static IActorsRepository GetActorsRepositoryInstance()
        {
            var dbContext = DbContextUtilities.MovieListingsDbContext;
            var actorsRepository = new ActorsRepository(dbContext);
            return actorsRepository;
        }

        internal static IMoviesRepository GetMoviesRepositoryInstance()
        {
            var dbContext = DbContextUtilities.MovieListingsDbContext;
            var moviesRepository = new MoviesRepository(dbContext);
            return moviesRepository;
        }

        internal static IMovieThumbnailsRepository GetMovieThumbnailsRepositoryInstance()
        {
            var dbContext = DbContextUtilities.MovieListingsDbContext;
            var movieThumbnailsRepository = new MovieThumbnailsRepository(dbContext);
            return movieThumbnailsRepository;
        }

    }
}