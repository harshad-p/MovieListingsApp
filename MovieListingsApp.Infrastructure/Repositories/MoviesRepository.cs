using MovieListingsApp.Core.Contracts.Repositories;
using MovieListingsApp.Core.Entities;
using MovieListingsApp.Entities;
using MovieListingsApp.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
                            .Include("MovieActors.Actor")
                            .ToListAsync();
        }

        public Task<TblMovie> GetByIdHeavyAsync(int id)
        {
            return _entities.Where(m => m.Id == id)
                            .Include("MovieActors.Movie")
                            .Include("MovieActors.Actor")
                            .SingleOrDefaultAsync();
        }
    }
}