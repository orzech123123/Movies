using Movies.ApiModels;
using Movies.Utils;
using Newtonsoft.Json;

namespace Movies.Services
{
    public class ApiService
    {
        private const string ApiKey = "463c4d8dcdc584ff3e8977bd93d207a0";

        public static GenreCollection GetGenres()
        {
            var response = RequestHelper.Get($"https://api.themoviedb.org/3/genre/movie/list?language=pl-PL&api_key={ApiKey}");

            return JsonConvert.DeserializeObject<GenreCollection>(response);
        }

        public static MovieCollection GetMovies(int genreId)
        {
            var response = RequestHelper.Get($"https://api.themoviedb.org/3/discover/movie?with_genres={genreId}&sort_by=vote_average.asc&language=pl-PL&api_key={ApiKey}");

            return JsonConvert.DeserializeObject<MovieCollection>(response);
        }
    }
}