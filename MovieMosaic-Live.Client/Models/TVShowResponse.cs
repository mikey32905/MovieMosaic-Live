namespace MovieMosaic_Live.Client.Models
{
    public class TVShowResponse
    {
        public int Page { get; set; }
        public List<TVShow> Results { get; set; } = [];
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
    }
}
