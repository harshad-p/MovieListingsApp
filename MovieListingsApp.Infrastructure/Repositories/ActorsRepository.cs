using MovieListingsApp.Core.Contracts.Repositories;
using MovieListingsApp.Core.Entities;
using MovieListingsApp.Entities;
using MovieListingsApp.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MovieListingsApp.Infrastructure.Repositories
{
    public class ActorsRepository : BaseRepository<TblActor>, IActorsRepository
    {
        public ActorsRepository(MovieListingsDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<TblActor>> GetAllHeavyAsync()
        {
            return _entities.Include("MovieActors.Movie")
                            .ToListAsync();
        }
    }
}