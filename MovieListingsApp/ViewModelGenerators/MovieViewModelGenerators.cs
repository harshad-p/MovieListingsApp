using MovieListingsApp.Contracts.ViewModelGenerators;
using MovieListingsApp.Core.Contracts.Repositories;
using MovieListingsApp.Entities;
using MovieListingsApp.Models.MovieModels;
using MovieListingsApp.Models.UserPrivileges;
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

        public async Task<DetailsViewModel> GetDetailsViewModelAsync(int id)
        {
            try
            {
                var movie = await _moviesRepository.GetByIdHeavyAsync(id);
                if(movie == null)
                {
                    throw new Exception($"Movie [Id: {id}] not found.");
                }

                var thumbnailIds = _movieThumbnailsRepository.GetAllIdsForMovieAsync(movie.Id).Result;

                var detailsViewModel = new DetailsViewModel
                {
                    Id = movie.Id, 
                    Title = movie.Title, 
                    Description = movie.Description, 
                    Year = movie.Year, 
                    ThumbnailIds = thumbnailIds, 
                    MovieUserPrivileges = new MovieUserPrivileges
                    {
                        
                    }
                };

                foreach(var actor in movie.MovieActors)
                {
                    detailsViewModel.Actors.Add(BuildActor(actor));
                }

                return detailsViewModel;
            }
            catch (Exception)
            {
                // log exception. 
                return null;
            }
        }

        private Actor BuildActor(TblMovieActor movieActor)
        {
            return new Actor
            {
                Id = movieActor.Actor.Id, 
                Name = movieActor.Actor.Name, 
                Gender = movieActor.Actor.Gender.ToString()
            };
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