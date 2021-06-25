using MovieListingsApp.Entities;
using System.Threading.Tasks;

namespace MovieListingsApp.Contracts.Services
{
    public interface IMovieThumbnailsService
    {
        Task<TblMovieThumbnail> GetByIdAsync(long id, bool includeBinaryData);
    }
}