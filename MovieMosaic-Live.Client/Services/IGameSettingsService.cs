using MovieMosaic_Live.Client.Components.UI;
using MovieMosaic_Live.Client.Models;

namespace MovieMosaic_Live.Client.Services
{
    public interface IGameSettingsService
    {
        Task<MovieMosaicGameSettings> GetMovieMosaicGameSettings();
        Task SaveMovieMosaicGameSettingsAsync(GameSettings gameSettings);

        Task<ShowMosaicGameSettings> GetShowMosaicGameSettings();
        Task SaveShowMosaicGameSettingsAsync(GameSettings gameSettings);
    }
}
