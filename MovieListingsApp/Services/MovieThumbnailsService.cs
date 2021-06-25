using Microsoft.Extensions.Logging;
using MovieListingsApp.Contracts.Services;
using MovieListingsApp.Core.Contracts.Repositories;
using MovieListingsApp.Entities;
using System;
using System.Threading.Tasks;

namespace MovieListingsApp.Services
{
    public class MovieThumbnailsService : IMovieThumbnailsService
    {
        //private ILogger<IMovieThumbnailsService> _logger;
        private readonly IMovieThumbnailsRepository _movieThumbnailsRepository;

        public MovieThumbnailsService(
            //ILogger<IMovieThumbnailsService> logger,
                                      IMovieThumbnailsRepository movieThumbnailsRepository)
        {
            //_logger = logger;
            _movieThumbnailsRepository = movieThumbnailsRepository;
        }

        /// <summary>
        /// Gets the Movie Thumbnail information 
        /// with the binary data if required. 
        /// Helpful to avoid loading the binary data from database 
        /// if the thumbnail was very large in size. 
        /// </summary>
        /// <param name="id">The Id of the Thumbnail.</param>
        /// <param name="includeBinaryData">if true: includes the binary data of the thumbnail; 
        /// if false: does not.</param>
        /// <returns>A Task of Movie Thumbnail object.</returns>
        public async Task<TblMovieThumbnail> GetByIdAsync(long id, bool includeBinaryData)
        {
            try
            {
                TblMovieThumbnail thumbnail;
                if (includeBinaryData)
                {
                    thumbnail = await _movieThumbnailsRepository.GetByIdAsync(id);
                }
                else
                {
                    thumbnail = await _movieThumbnailsRepository.GetByIdLightAsync(id);
                }

                return thumbnail;
            }
            catch (Exception e)
            {
                //_logger.LogError(e.Message);
                return null;
            }
        }
    }
}