using MovieMosaic_Live.Client.Models;

namespace MovieMosaic_Live.Client.Services
{
    public interface ITMDBService
    {
        Task<Movie> GetRandomMovieAsync(int? yearStart, int? yearEnd, string? Genres);

        Task<List<Movie>> SearchMoviesAsync(string query, int page = 1);
    }
}
