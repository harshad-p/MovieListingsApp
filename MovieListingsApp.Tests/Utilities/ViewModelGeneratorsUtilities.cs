using MovieListingsApp.Contracts.ViewModelGenerators;
using MovieListingsApp.ViewModelGenerators;

namespace MovieListingsApp.Tests.Utilities
{
    class ViewModelGeneratorsUtilities
    {
        internal static IMovieViewModelGenerators GetMovieViewModelGeneratorsInstance()
        {
            var moviesRepository = RepositoryUtilities.GetMoviesRepositoryInstance();
            var movieThumbnailsRepository = RepositoryUtilities.GetMovieThumbnailsRepositoryInstance();
            var movieViewModelGenerators = new MovieViewModelGenerators(moviesRepository, movieThumbnailsRepository);
            return movieViewModelGenerators;
        }

    }
}