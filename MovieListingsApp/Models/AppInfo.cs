using System.Reflection;

namespace MovieListingsApp.Models
{
    public class AppInfo
    {
        public static string Name => "Movie Listings App";
        public static string Description => "An Asp.Net Razor MVC 5 website that displays movie listings. " +
            "Listing page shows a list of movies, including a distinct thumbnail image.";
        public static string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }
}