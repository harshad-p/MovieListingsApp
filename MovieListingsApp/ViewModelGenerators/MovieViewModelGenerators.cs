using MovieListingsApp.Contracts.ViewModelGenerators;
using MovieListingsApp.Core.Contracts.Repositories;
using MovieListingsApp.Entities;
using MovieListingsApp.Models;
using System;
using System.Threading.Tasks;

namespace MovieListingsApp.ViewModelGenerators
{
    public class MovieViewModelGenerators : IMovieViewModelGenerators
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly IMovieThumbnailsRepository _movieThumbnailsRepository;

        public MovieViewModelGenerators(IMoviesRepository moviesRepository, IMovieThumbnailsRepository movieThumbnailsRepository)
        {
            _moviesRepository = moviesRepository;
            _movieThumbnailsRepository = movieThumbnailsRepository;
        }

        public async Task<IndexViewModel> GetIndexViewModelAsync()
        {
            try
            {
                var indexViewModel = new IndexViewModel 
                { 
                    CanCreate = true
                };

                var movies = await _moviesRepository.GetAllHeavyAsync();
                foreach(var movie in movies)
                {
                    indexViewModel.Movies.Add(BuildMovie(movie));
                }

                return indexViewModel;
            }
            catch (Exception)
            {
                // log exception. 
                return null;
            }
        }

        private Movie BuildMovie(TblMovie movie)
        {
            var thumbnailIds = _movieThumbnailsRepository.GetAllIdsForMovieAsync(movie.Id).Result;

            return new Movie
            {
                Id = movie.Id, 
                Title = movie.Title, 
                Description = movie.Description, 
                Year = movie.Year, 
                ThumbnailIds = thumbnailIds
            };
        }
    }
}