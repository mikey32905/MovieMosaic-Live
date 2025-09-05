using Microsoft.JSInterop;
using MovieMosaic_Live.Client.Components.UI;
using MovieMosaic_Live.Client.Models;
using System.Text.Json;

namespace MovieMosaic_Live.Client.Services
{
    public class GamesSettingsService(IJSRuntime jsRuntime) : IGameSettingsService
    {
        private readonly string _movieLocalStorageKey = "MovieMosaicGameSettings";
        private readonly string _tvLocalStorageKey = "ShowMosaicGameSettings";

        public async Task<MovieMosaicGameSettings> GetMovieMosaicGameSettings()
        {
            MovieMosaicGameSettings gameSettings = new MovieMosaicGameSettings();

            try
            {
                var json = await jsRuntime.InvokeAsync<string>("localStorage.getItem", _movieLocalStorageKey);
                gameSettings = JsonSerializer.Deserialize<MovieMosaicGameSettings>(json) ?? new MovieMosaicGameSettings();
            }
            catch (Exception)
            {
                Console.WriteLine("No Movie Mosaic game settings found in local storage. Using default settings.");
            }

            return gameSettings;
        }

        public async Task SaveMovieMosaicGameSettingsAsync(GameSettings gameSettings)
        {
            try
            {
                var json = JsonSerializer.Serialize(gameSettings);
                await jsRuntime.InvokeVoidAsync("localStorage.setItem", _movieLocalStorageKey, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving Movie Mosaic game settings to local storage: {ex.Message}");
            }
        }

        public async Task<ShowMosaicGameSettings> GetShowMosaicGameSettings()
        {
            ShowMosaicGameSettings gameSettings = new ShowMosaicGameSettings();

            try
            {
                var json = await jsRuntime.InvokeAsync<string>("localStorage.getItem", _tvLocalStorageKey);
                gameSettings = JsonSerializer.Deserialize<ShowMosaicGameSettings>(json) ?? new ShowMosaicGameSettings();
            }
            catch (Exception)
            {
                Console.WriteLine("No Show Mosaic game settings found in local storage. Using default settings.");
            }

            return gameSettings;
        }

        public async Task SaveShowMosaicGameSettingsAsync(GameSettings gameSettings)
        {
            try
            {
                var json = JsonSerializer.Serialize(gameSettings);
                await jsRuntime.InvokeVoidAsync("localStorage.setItem", _tvLocalStorageKey, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving Movie Mosaic game settings to local storage: {ex.Message}");
            }
        }


    }
}
