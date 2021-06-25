using MovieListingsApp.Core.Contracts.Repositories;
using MovieListingsApp.Core.Entities;
using MovieListingsApp.Entities;
using MovieListingsApp.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MovieListingsApp.Infrastructure.Repositories
{
    public class MoviesRepository : BaseRepository<TblMovie>, IMoviesRepository
    {
        public MoviesRepository(MovieListingsDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<TblMovie>> GetAllHeavyAsync()
        {
            return _entities.Include("MovieActors.Movie")
                            .ToListAsync();
        }
    }
}