namespace MovieMosaic_Live.Client.Models
{
    public class MovieResponse
    {
        public int Page { get; set; }
        public List<Movie> Results { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
    }
}
