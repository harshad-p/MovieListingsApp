using MovieListingsApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieListingsApp.Core.Contracts.Repositories
{
    public interface IMoviesRepository : IGenericRepository<TblMovie>, IGenericRepositoryAsync<TblMovie>
    {
        Task<List<TblMovie>> GetAllHeavyAsync();
        Task<TblMovie> GetByIdHeavyAsync(int id);
    }
}