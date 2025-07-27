namespace MovieMosaic_Live.Client.Models
{
    public class TVShow
    {
        public bool Adult { get; set; }
        public string BackdropPath { get; set; }
        public int[] GenreIds { get; set; }
        public int Id { get; set; }
        public string[] OriginCountry { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalName { get; set; }
        public string Overview { get; set; }
        public float Popularity { get; set; }
        public string PosterPath { get; set; }
        public string FirstAirDate { get; set; }
        public string Name { get; set; }
        public float VoteAverage { get; set; }
        public int VoteCount { get; set; }
    }
}
