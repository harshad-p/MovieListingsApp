using MovieListingsApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieListingsApp.Core.Contracts.Repositories
{
    public interface IMovieThumbnailsRepository : IGenericRepository<TblMovieThumbnail>, IGenericRepositoryAsync<TblMovieThumbnail>
    {
        //Task<List<TblMovieThumbnail>> GetAllForMovieLightAsync(int movieId);
        Task<TblMovieThumbnail> GetByIdLightAsync(long id);
        Task<List<long>> GetAllIdsForMovieAsync(int movieId);
        Task<int> GetMovieIdAsync(int id);
    }
}