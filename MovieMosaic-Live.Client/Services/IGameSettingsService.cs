using MovieMosaic_Live.Client.Models;

namespace MovieMosaic_Live.Client.Services
{
    public interface IGameSettingsService
    {
        Task<MovieMosaicGameSettings> GetMovieMosaicGameSettings();
        Task SaveMovieMosaicGameSettingsAsync(MovieMosaicGameSettings gameSettings);

        Task<ShowMosaicGameSettings> GetShowMosaicGameSettings();
        Task SaveShowMosaicGameSettingsAsync(ShowMosaicGameSettings gameSettings);
    }
}
