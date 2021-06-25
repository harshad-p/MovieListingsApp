using MovieListingsApp.Contracts.Services;
using MovieListingsApp.Core.Contracts.Repositories;
using MovieListingsApp.Entities;
using System;
using System.Threading.Tasks;

namespace MovieListingsApp.Services
{
    public class MovieThumbnailsService : IMovieThumbnailsService
    {
        private readonly IMovieThumbnailsRepository _movieThumbnailsRepository;

        public MovieThumbnailsService(IMovieThumbnailsRepository movieThumbnailsRepository)
        {
            _movieThumbnailsRepository = movieThumbnailsRepository;
        }

        public async Task<TblMovieThumbnail> GetByIdLightAsync(long id)
        {
            try
            {
                var thumbnail = await _movieThumbnailsRepository.GetByIdAsync(id);
                return thumbnail;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}