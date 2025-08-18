using MovieMosaic_Live.Client.Models;

namespace MovieMosaic_Live.Client.Services
{
    public interface ITMDBService
    {
        Task<Movie> GetRandomMovieAsync(int? yearStart, int? yearEnd, string? Genres);

        Task<List<Movie>> SearchMoviesAsync(string query, int page = 1);

        Task<MovieDetails> GetMovieDetailsAsync(int movieId);
        Task<TVShow> GetRandomTVShowAsync(int? yearStart, int? yearEnd, string? Genres);

        Task<List<TVShow>> SearchTVShowsAsync(string query, int page = 1);

        Task<TVShowDetails> GetTVShowDetailsAsync(int tvShowId);
    }
}
