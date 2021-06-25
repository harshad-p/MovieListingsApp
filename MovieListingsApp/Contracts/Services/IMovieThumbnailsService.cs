using MovieListingsApp.Entities;
using System.Threading.Tasks;

namespace MovieListingsApp.Contracts.Services
{
    public interface IMovieThumbnailsService
    {
        Task<TblMovieThumbnail> GetByIdLightAsync(long id);
    }
}