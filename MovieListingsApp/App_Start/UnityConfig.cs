using Effort;
using MovieListingsApp.Contracts.Services;
using MovieListingsApp.Core.Contracts.Repositories;
using MovieListingsApp.Core.Entities;
using MovieListingsApp.Infrastructure.Repositories;
using MovieListingsApp.Models;
using MovieListingsApp.Services;
using System.Web.Mvc;
using Unity;
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

            var appName = AppInfo.Name;
            var connection = DbConnectionFactory.CreatePersistent(appName);
            var context = new MovieListingsDbContext(connection);

            container.RegisterInstance<IActorsRepository>(new ActorsRepository(context));

            container.RegisterType<IActorsService, ActorsService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}