using Effort;
using MovieListingsApp.Core.Entities;
using MovieListingsApp.Core.Models;
using MovieListingsApp.Entities;
using MovieListingsApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieListingsApp.Data
{
    public class MovieListingDataSeeder
    {
        private MovieListingsDbContext _context;

        public MovieListingDataSeeder()
        {
            //var loader = new Effort.DataLoaders.CsvDataLoader();
            var appName = AppInfo.Name;
            var connection = DbConnectionFactory.CreatePersistent(appName);
            _context = new MovieListingsDbContext(connection);
        }

        public async Task Seed()
        {
            await LoadActorsAsync();
            await LoadMoviesAsync();
            await AddMovieActorsAsync();
        }

        private async Task AddMovieActorsAsync()
        {
            if(!_context.Movies.Any() || !_context.Actors.Any())
            {
                return;
            }
            var movieActors = GetMovieActors();
            _context.MovieActors.AddRange(movieActors);
            await _context.SaveChangesAsync();
        }

        private List<TblMovieActor> GetMovieActors()
        {
            var arnold = _context.Actors.Single(a => a.Name.Contains("Arnold"));
            var scarlett = _context.Actors.Single(a => a.Name.Contains("Scarlett"));
            var arnoldMovies = _context.Movies.Where(m => m.Title.Contains("Terminator"));
            var scarlettMovies = _context.Movies.Where(m => m.Title.Contains("Black Widow"));

            var movieActors = new List<TblMovieActor>();

            foreach(var arnoldMovie in arnoldMovies)
            {
                movieActors.Add(new TblMovieActor
                {
                    MovieId = arnoldMovie.Id, 
                    ActorId = arnold.Id
                });
            }

            foreach (var scarlettMovie in scarlettMovies)
            {
                movieActors.Add(new TblMovieActor
                {
                    MovieId = scarlettMovie.Id,
                    ActorId = scarlett.Id
                });
            }

            return movieActors;
        }

        private async Task LoadMoviesAsync()
        {
            if (!_context.Movies.Any())
            {
                var movies = GetMovies();
                _context.Movies.AddRange(movies);
                await _context.SaveChangesAsync();
            }
        }

        private List<TblMovie> GetMovies()
        {
            var movies = new List<TblMovie>
            {
                new TblMovie
                {
                    Title = "Terminator", 
                    Description = "Terminator", 
                    Year = 1984, 
                },
                new TblMovie
                {
                    Title = "Black Widow",
                    Description = "Black Widow",
                    Year = 2021,
                }
            };

            return movies;
        }

        private async Task LoadActorsAsync()
        {
            if (!_context.Actors.Any())
            {
                var actors = GetActors();
                _context.Actors.AddRange(actors);
                await _context.SaveChangesAsync();
            }
        }

        private List<TblActor> GetActors()
        {
            var actors = new List<TblActor>
            {
                new TblActor
                {
                    Gender = Gender.Male,
                    Name = "Arnold Schwarzenegger"
                },
                new TblActor
                {
                    Gender = Gender.Female,
                    Name = "Scarlett Johansson"
                }
            };

            return actors;
        }
    }
}