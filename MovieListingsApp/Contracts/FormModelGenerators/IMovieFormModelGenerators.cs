using MovieListingsApp.Models.MovieModels;
using System.Threading.Tasks;

namespace MovieListingsApp.Contracts.FormModelGenerators
{
    public interface IMovieFormModelGenerators
    {
        Task<CreateFormModel> GetCreateFormModelAsync();
    }
}