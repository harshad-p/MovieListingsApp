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
    public class MovieThumbnailsRepository : BaseRepository<TblMovieThumbnail>, IMovieThumbnailsRepository
    {
        public MovieThumbnailsRepository(MovieListingsDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<TblMovieThumbnail>> GetAllForMovieLightAsync(int movieId)
        {
            return _entities.Where(a => a.MovieId == movieId)
                            .Select(a => new TblMovieThumbnail
                            {
                                Id = a.Id,
                                MovieId = a.MovieId, 
                                TimeStampUtc = a.TimeStampUtc,
                                ContentType = a.ContentType,
                                FileName = a.FileName
                            })
                            .ToListAsync();
        }

        public Task<TblMovieThumbnail> GetByIdLightAsync(long id)
        {
            return _entities.Where(a => a.Id == id)
                            .Select(a => new TblMovieThumbnail
                            {
                                Id = a.Id,
                                MovieId = a.MovieId, 
                                TimeStampUtc = a.TimeStampUtc,
                                ContentType = a.ContentType,
                                FileName = a.FileName
                            })
                            .SingleOrDefaultAsync();
        }

        public Task<List<long>> GetAllIdsForMovieAsync(int movieId)
        {
            return _entities.Where(a => a.MovieId == movieId)
                            .Select(a => a.Id)
                            .ToListAsync();
        }

        public Task<int> GetMovieIdAsync(int id)
        {
            return _entities.Where(u => u.Id == id)
                            .Select(u => u.MovieId)
                            .SingleOrDefaultAsync();
        }

    }
}