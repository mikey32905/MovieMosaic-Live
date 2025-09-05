using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MovieMosaic_Live.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<IGameSettingsService, GamesSettingsService>();

await builder.Build().RunAsync();
