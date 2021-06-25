using MovieListingsApp.Contracts.FormModelGenerators;
using MovieListingsApp.FormModelGenerators;

namespace MovieListingsApp.Tests.Utilities
{
    class FormModelGeneratorsUtilities
    {
        internal static IMovieFormModelGenerators GetMovieFormModelGeneratorsInstance()
        {
            var actorsRepository = RepositoryUtilities.GetActorsRepositoryInstance();
            var movieFormModelGenerators = new MovieFormModelGenerators(actorsRepository);
            return movieFormModelGenerators;
        }

    }
}