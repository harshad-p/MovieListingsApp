using Effort;
using MovieListingsApp.Core.Entities;
using MovieListingsApp.Models;
using System.Data.Common;

namespace MovieListingsApp.Tests.Utilities
{
    class DbContextUtilities
    {
        private static MovieListingsDbContext _movieListingsDbContext = null;
        private static DbConnection _dbConnection = null;

        private DbContextUtilities()
        {
        }

        private static DbConnection DbConnection
        {
            get
            {
                if (_dbConnection == null)
                {
                    var appName = AppInfo.Name;
                    var connection = DbConnectionFactory.CreatePersistent(appName);
                    _dbConnection = connection;
                }
                return _dbConnection;
            }
        }

        public static MovieListingsDbContext MovieListingsDbContext
        {
            get
            {
                _movieListingsDbContext = new MovieListingsDbContext(DbConnection);
                return _movieListingsDbContext;
            }
        }

    }
}