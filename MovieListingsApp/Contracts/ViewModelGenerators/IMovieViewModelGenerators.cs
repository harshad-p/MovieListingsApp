using MovieListingsApp.Models;
using System.Threading.Tasks;

namespace MovieListingsApp.Contracts.ViewModelGenerators
{
    public interface IMovieViewModelGenerators
    {
        Task<IndexViewModel> GetIndexViewModelAsync();
    }
}