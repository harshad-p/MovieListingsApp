using Effort;
using MovieListingsApp.Contracts.Services;
using MovieListingsApp.Contracts.ViewModelGenerators;
using MovieListingsApp.Core.Contracts.Repositories;
using MovieListingsApp.Core.Entities;
using MovieListingsApp.Infrastructure.Repositories;
using MovieListingsApp.Models;
using MovieListingsApp.Services;
using MovieListingsApp.ViewModelGenerators;
using System.Data.Common;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
using Unity.Mvc5;

namespace MovieListingsApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            var connection = GetDbConnection();

            container.RegisterInstance<DbConnection>(connection);
            container.RegisterType<DbContext, MovieListingsDbContext>(new PerThreadLifetimeManager());
            //container.RegisterInstance<DbContext, MovieListingsDbContext>();

            // Repositories 
            //container.RegisterInstance<IActorsRepository>(new ActorsRepository(context));
            container.RegisterType<IActorsRepository, ActorsRepository>();
            container.RegisterType<IMoviesRepository, MoviesRepository>();
            container.RegisterType<IMovieThumbnailsRepository, MovieThumbnailsRepository>();

            // Services 
            container.RegisterType<IActorsService, ActorsService>();
            container.RegisterType<IMovieThumbnailsService, MovieThumbnailsService>();

            // View Model Generators
            container.RegisterType<IMovieViewModelGenerators, MovieViewModelGenerators>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static MovieListingsDbContext GetMovieListingsDbContext()
        {
            var connection = GetDbConnection();
            var context = new MovieListingsDbContext(connection);
            return context;
        }

        private static DbConnection GetDbConnection()
        {
            var appName = AppInfo.Name;
            var connection = DbConnectionFactory.CreatePersistent(appName);
            return connection;
        }
    }
}