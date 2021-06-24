using MovieListingsApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieListingsApp.Core.Contracts.Repositories
{
    public interface IActorsRepository : IGenericRepository<TblActor>, IGenericRepositoryAsync<TblActor>
    {
        Task<List<TblActor>> GetAllHeavyAsync();
    }
}