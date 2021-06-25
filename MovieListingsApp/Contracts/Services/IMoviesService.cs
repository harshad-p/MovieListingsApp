using MovieListingsApp.Models.MovieModels;
using System.Threading.Tasks;

namespace MovieListingsApp.Contracts.Services
{
    public interface IMoviesService
    {
        Task<int> CreateAsync(CreateViewModel createMovieViewModel);
    }
}