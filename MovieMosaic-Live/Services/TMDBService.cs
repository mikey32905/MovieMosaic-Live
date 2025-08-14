using MovieMosaic_Live.Client.Models;
using MovieMosaic_Live.Client.Services;
using System.Text.Json;

namespace MovieMosaic_Live.Services
{
    public class TMDBService : ITMDBService
    {
        private readonly HttpClient _http;
        public static readonly Random _random = new();

        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };

        public TMDBService(HttpClient http, IConfiguration config)
        {
            _http = http;

            const string configKey = "TmdbApiKey";

            string? devTmdbKey = config[configKey];
            string? prodTmdbKey = Environment.GetEnvironmentVariable(configKey);

            var tmdbKey = string.IsNullOrEmpty(devTmdbKey) ? prodTmdbKey : devTmdbKey;

            if (!string.IsNullOrEmpty(tmdbKey))
            {
                _http.BaseAddress = new Uri("https://api.themoviedb.org/3/");
                _http.DefaultRequestHeaders.Authorization = new("Bearer", tmdbKey);
            }
            else
            {
                Console.WriteLine($"No TMDB API key found in configuration. Please set the '{configKey}' environment variable or app setting.");
            }
        }

        /// <summary>
        /// Get a random movie based on the specific year range and genres.
        /// </summary>
        /// <param name="yearStart"></param>
        /// <param name="yearEnd"></param>
        /// <param name="Genres"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Movie> GetRandomMovieAsync(int? yearStart, int? yearEnd, string? Genres)
        {
            //get a random movie based on the specific year range and genres.
            string releaseDateGte = "";
            string releaseDateLte = "";

            string baseUrl = "discover/movie?include_adult=false&include_video=false&region=US&with_origin_country=US&with_original_language=en&sort_by=vote_count.desc&volt_count.gte=200";

            Movie randomMovie = new Movie();

            if (yearStart is not null && yearEnd is not null && yearStart < yearEnd)
            {
                releaseDateGte = $"{yearStart}-01-01";
                releaseDateLte = $"{yearEnd}-12-31";

                baseUrl += $"&release_date.gte={releaseDateGte}&release_date.lte={releaseDateLte}";
            }

            if (!string.IsNullOrEmpty(Genres))
            {
                baseUrl += $"&with_genres={Genres}";
            }

            int randomPage = _random.Next(1, 21); // Random page number between 1 and 20
            string discoverUrl = $"{baseUrl}&page={randomPage}";

            //get a random movie from discovered page.
            var initialResponse = await _http.GetFromJsonAsync<MovieResponse>(discoverUrl, _jsonOptions)
                ?? throw new HttpIOException(HttpRequestError.InvalidResponse, "Could not find a random movie.");

            //how many pages found?
            int totalPages = Math.Min(initialResponse.TotalPages, 500);

            //we need to filter movies that do not have a poster.
            var filteredMovies = initialResponse.Results.Where(m => !string.IsNullOrEmpty(m.PosterPath)).ToList();

            if (filteredMovies.Count > 0)
            {
                //get a random movie from filtered movies.
                int randomIndex = _random.Next(filteredMovies.Count);
                randomMovie = filteredMovies[randomIndex];
                randomMovie.PosterPath = $"https://image.tmdb.org/t/p/w500{randomMovie.PosterPath}"; // Set the full poster path
                return randomMovie;
            }

            //no movie found
            int retryPage = totalPages;

            if (totalPages > 1)
            {
                //retry with the last page
                retryPage = _random.Next(1, totalPages + 1);
            }

            string retryUrl = $"{baseUrl}&page={retryPage}";

            var retryResponse = await _http.GetFromJsonAsync<MovieResponse>(retryUrl, _jsonOptions)
                ?? throw new HttpIOException(HttpRequestError.InvalidResponse, "Could not find a random movie.");

            var filteredRetryMovies = retryResponse.Results.Where(m => !string.IsNullOrEmpty(m.PosterPath)).ToList();

            if (filteredRetryMovies.Count > 1)
            {
                int randomIndex = _random.Next(filteredRetryMovies.Count);
                randomMovie = filteredRetryMovies[randomIndex];
                randomMovie.PosterPath = $"https://image.tmdb.org/t/p/w500{randomMovie.PosterPath}"; // Set the full poster path
                return randomMovie;
            }

            throw new HttpIOException(HttpRequestError.InvalidResponse, "Could not find a random movie");
        }

        /// <summary>
        /// Search for movies based on a query string.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <exception cref="HttpIOException"></exception>
        public async Task<List<Movie>> SearchMoviesAsync(string query, int page = 1)
        {
            var url = $"search/movie?query={query}&region=US&include_adult=false&language=en-US";

            MovieResponse response = await _http.GetFromJsonAsync<MovieResponse>(url, _jsonOptions)
                ?? throw new HttpIOException(HttpRequestError.InvalidResponse, "Search results could not be loaded.");

            return response.Results.Where(r => r.VoteCount > 150).ToList();
        }

        public async Task<MovieDetails> GetMovieDetailsAsync(int movieId)
        {
            var url = $"movie/{movieId}?append_to_response=credits,videos&language=en-US";

            MovieDetails? response = await _http.GetFromJsonAsync<MovieDetails>(url, _jsonOptions)
                ?? throw new HttpIOException(HttpRequestError.InvalidResponse, "Movie details could not be loaded.");

            return response;
        }

        public async Task<TVShow> GetRandomTVShowAsync(int? yearStart, int? yearEnd, string? Genres)
        {
            //get a TV Show based on the specific year range and genres.
            string firstAirDateGte = "";
            string firstAirDateLte = "";

            string baseUrl = "discover/tv?include_adult=false&include_null_first_air_dates=false&language=en-US&with_origin_country=US&with_original_language=en&sort_by=vote_count.desc&volt_count.gte=200";


            TVShow randomTVShow = new TVShow();

            if (yearStart is not null && yearEnd is not null && yearStart < yearEnd)
            {
                firstAirDateGte = $"{yearStart}-01-01";
                firstAirDateLte = $"{yearEnd}-12-31";
                baseUrl += $"&first_air_date.gte={firstAirDateGte}&first_air_date.lte={firstAirDateLte}";
            }

            if (!string.IsNullOrEmpty(Genres))
            {
                baseUrl += $"&with_genres={Genres}";
            }

            int randomPage = _random.Next(1, 21); // Random page number between 1 and 20
            string discoverUrl = $"{baseUrl}&page={randomPage}";

            //get a random TV Show from discovered page.
            var initialResponse = _http.GetFromJsonAsync<TVShowResponse>(discoverUrl, _jsonOptions)
                .GetAwaiter().GetResult() ?? throw new HttpIOException(HttpRequestError.InvalidResponse, "Could not find a random TV Show.");

            //how many pages found?
            int totalPages = Math.Min(initialResponse.TotalPages, 500);

            //we need to filter TV Shows that do not have a poster.
            var filteredTVShows = initialResponse.Results.Where(m => !string.IsNullOrEmpty(m.PosterPath)).ToList();

            if (filteredTVShows.Count > 0)
            {
                //get a random TV Show from filtered TV Shows.
                int randomIndex = _random.Next(filteredTVShows.Count);
                randomTVShow = filteredTVShows[randomIndex];
                randomTVShow.PosterPath = $"https://image.tmdb.org/t/p/w500{randomTVShow.PosterPath}"; // Set the full poster path
                return randomTVShow;
            }

            //no TV Show found
            int retryPage = totalPages;

            if (totalPages > 1)
            {
                //retry with the last page
                retryPage = _random.Next(1, totalPages + 1);
            }

            string retryUrl = $"{baseUrl}&page={retryPage}";

            var retryResponse = _http.GetFromJsonAsync<TVShowResponse>(retryUrl, _jsonOptions)
                .GetAwaiter().GetResult() ?? throw new HttpIOException(HttpRequestError.InvalidResponse, "Could not find a random TV Show.");

            var filteredRetryTVShows = retryResponse.Results.Where(m => !string.IsNullOrEmpty(m.PosterPath)).ToList();

            if (filteredRetryTVShows.Count > 1)
            {
                int randomIndex = _random.Next(filteredRetryTVShows.Count);
                randomTVShow = filteredRetryTVShows[randomIndex];
                randomTVShow.PosterPath = $"https://image.tmdb.org/t/p/w500{randomTVShow.PosterPath}"; // Set the full poster path
                return randomTVShow;
            }

            throw new HttpIOException(HttpRequestError.InvalidResponse, "Could not find a random TV show");

        }

        public async Task<List<TVShow>> SearchTVShowsAsync(string query, int page = 1)
        {
            var url = $"search/tv?query={query}&region=US&include_adult=false&language=en-US";

            TVShowResponse response = _http.GetFromJsonAsync<TVShowResponse>(url, _jsonOptions)
                .GetAwaiter().GetResult() ?? throw new HttpIOException(HttpRequestError.InvalidResponse, "Search results could not be loaded.");

            return response.Results.Where(r => r.VoteCount > 150).ToList();
        }
    }
}
