using MovieListingsApp.Contracts.Services;
using MovieListingsApp.Services;

namespace MovieListingsApp.Tests.Utilities
{
    class ServiceUtilities
    {
        internal static IActorsService GetActorsServiceInstance()
        {
            var actorsRepository = RepositoryUtilities.GetActorsRepositoryInstance();
            var actorsService = new ActorsService(actorsRepository);
            return actorsService;
        }

        internal static IMoviesService GetMoviesServiceInstance()
        {
            var moviesRepository = RepositoryUtilities.GetMoviesRepositoryInstance();
            var moviesService = new MoviesService(moviesRepository);
            return moviesService;
        }

        internal static IMovieThumbnailsService GetMovieThumbnailsServiceInstance()
        {
            var movieThumbnailsRepository = RepositoryUtilities.GetMovieThumbnailsRepositoryInstance();
            var movieThumbnailsService = new MovieThumbnailsService(movieThumbnailsRepository);
            return movieThumbnailsService;
        }

    }
}