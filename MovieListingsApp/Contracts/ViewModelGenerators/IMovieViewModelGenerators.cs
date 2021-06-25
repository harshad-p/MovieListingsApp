using MovieListingsApp.Models.MovieModels;
using System.Threading.Tasks;

namespace MovieListingsApp.Contracts.ViewModelGenerators
{
    public interface IMovieViewModelGenerators
    {
        Task<IndexViewModel> GetIndexViewModelAsync();
        Task<DetailsViewModel> GetDetailsViewModelAsync(int id);
    }
}