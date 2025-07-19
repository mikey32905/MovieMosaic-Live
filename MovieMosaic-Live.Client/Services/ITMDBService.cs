using MovieMosaic_Live.Client.Models;

namespace MovieMosaic_Live.Client.Services
{
    public interface ITMDBService
    {
        Task<Movie> GetRandomMovieAsync(int? yearStart, int? yearEnd, string? Genres);


    }
}
