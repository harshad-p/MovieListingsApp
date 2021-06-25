using Effort;
using MovieListingsApp.Core.Entities;
using MovieListingsApp.Core.Models;
using MovieListingsApp.Entities;
using MovieListingsApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Hosting;

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
                    Thumbnails = GetTerminatorThumbnails()
                },
                new TblMovie
                {
                    Title = "Black Widow",
                    Description = "Black Widow",
                    Year = 2021,
                    Thumbnails = GetBlackWidowThumbnails()
                }
            };

            return movies;
        }

        private ICollection<TblMovieThumbnail> GetTerminatorThumbnails()
        {
            var imgName = "Terminator.jpg";
            var thumbnails = new List<TblMovieThumbnail>();
            thumbnails.Add(BuildMovieThumbnail(imgName));
            return thumbnails;
        }

        private ICollection<TblMovieThumbnail> GetBlackWidowThumbnails()
        {
            var imgName = "Black-Widow.jpg"; 
            var thumbnails = new List<TblMovieThumbnail>();
            thumbnails.Add(BuildMovieThumbnail(imgName));
            return thumbnails;
        }

        private string BuildImgPath(string imgName)
        {
            var appDirectory = HostingEnvironment.ApplicationPhysicalPath;
            var imgDirectory = Path.Combine(appDirectory, "App_Data", "img");
            var imgPath = Path.Combine(imgDirectory, imgName);
            return imgPath;
        }

        private TblMovieThumbnail BuildMovieThumbnail(string imgName)
        {
            var imgPath = BuildImgPath(imgName);

            var thumbnail = new TblMovieThumbnail
            {
                ContentType = "image/jpeg",
                FileName = imgName,
                TimeStampUtc = DateTime.UtcNow,
            };

            using (var stream = new FileStream(imgPath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(stream);
                long byteLength = new FileInfo(imgPath).Length;
                thumbnail.Content = binaryReader.ReadBytes((Int32)byteLength);
                binaryReader.Close();
            }

            return thumbnail;
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