using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieListingsApp.Contracts.FormModelGenerators;
using MovieListingsApp.Contracts.Services;
using MovieListingsApp.Contracts.ViewModelGenerators;
using MovieListingsApp.Controllers;
using MovieListingsApp.Tests.Utilities;
using System.Web.Mvc;

namespace MovieListingsApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private readonly IMovieViewModelGenerators _movieViewModelGenerators;
        private readonly IMovieFormModelGenerators _movieFormModelGenerators;
        private readonly IMoviesService _moviesService;

        public HomeControllerTest()
        {
            _movieViewModelGenerators = ViewModelGeneratorsUtilities.GetMovieViewModelGeneratorsInstance();
            _movieFormModelGenerators = FormModelGeneratorsUtilities.GetMovieFormModelGeneratorsInstance();
            _moviesService = ServiceUtilities.GetMoviesServiceInstance();
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(_movieViewModelGenerators, _movieFormModelGenerators, _moviesService);

            // Act
            var result = controller.Index().Result as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(_movieViewModelGenerators, _movieFormModelGenerators, _moviesService);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController(_movieViewModelGenerators, _movieFormModelGenerators, _moviesService);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
