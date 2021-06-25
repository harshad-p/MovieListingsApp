using MovieListingsApp.Contracts.Services;
using MovieListingsApp.Core.Contracts.Repositories;
using MovieListingsApp.Entities;
using MovieListingsApp.Models.MovieModels;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MovieListingsApp.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        /// <summary>
        /// Creates a Movie Listing and adds the requried Actors and Thumbnails.
        /// </summary>
        /// <param name="createMovieViewModel">View Model for a Movie.</param>
        /// <returns>Movie Id: if succesfully created a movie listing; 
        /// -1: otherwise.</returns>
        public async Task<int> CreateAsync(CreateViewModel createMovieViewModel)
        {
            try
            {
                var movie = new TblMovie
                {
                    Title = createMovieViewModel.Title,
                    Description = createMovieViewModel.Description,
                    Year = createMovieViewModel.Year,
                };

                foreach(var actor in createMovieViewModel.Actors)
                {
                    movie.MovieActors.Add(new TblMovieActor
                    {
                        ActorId = actor
                    });
                }

                foreach (var thumbnail in createMovieViewModel.Thumbnails)
                {
                    if (thumbnail != null)
                    {
                        var fileName = Path.GetFileName(thumbnail.FileName);
                        
                        using (var memoryStream = new MemoryStream())
                        {
                            thumbnail.InputStream.CopyTo(memoryStream);
                            var movieThumbnail = new TblMovieThumbnail
                            {
                                ContentType = thumbnail.ContentType, 
                                FileName = fileName, 
                                Content = memoryStream.ToArray(), 
                                TimeStampUtc = DateTime.UtcNow, 
                            };
                            movie.Thumbnails.Add(movieThumbnail);
                        }
                    }
                }

                _moviesRepository.Add(movie);
                await _moviesRepository.SaveAsync();

                return movie.Id;
            }
            catch (Exception)
            {
                // log exception
                return -1;
            }
        }
    }
}