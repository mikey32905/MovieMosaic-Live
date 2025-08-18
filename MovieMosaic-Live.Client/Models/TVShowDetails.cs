namespace MovieMosaic_Live.Client.Models
{
    public class TVShowDetails
    {
        public bool? Adult { get; set; }
        public string BackdropPath { get; set; }
        public List<CreatedBy> CreatedBy { get; set; }
        public List<object> EpisodeRunTime { get; set; }
        public string FirstAirDate { get; set; }
        public List<Genre> Genres { get; set; }
        public string Homepage { get; set; }
        public int? Id { get; set; }
        public bool? InProduction { get; set; }
        public List<string> Languages { get; set; }
        public string LastAirDate { get; set; }
        public LastEpisodeToAir LastEpisodeToAir { get; set; }
        public string Name { get; set; }
        public NextEpisodeToAir NextEpisodeToAir { get; set; }
        public List<Network> Networks { get; set; }
        public int? NumberOfEpisodes { get; set; }
        public int? NumberOfSeasons { get; set; }
        public List<string> OriginCountry { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalName { get; set; }
        public string Overview { get; set; }
        public double? Popularity { get; set; }
        public string PosterPath { get; set; }
        public List<ProductionCompany> ProductionCompanies { get; set; }
        public List<ProductionCountry> ProductionCountries { get; set; }
        public List<Season> Seasons { get; set; }
        public List<SpokenLanguage> SpokenLanguages { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Type { get; set; }
        public double? VoteAverage { get; set; }
        public int? VoteCount { get; set; }
        public Credits Credits { get; set; }
        public Videos Videos { get; set; }
    }

    //public class Cast
    //{
    //    public bool? Adult { get; set; }
    //    public int? Gender { get; set; }
    //    public int? Id { get; set; }
    //    public string KnownForDepartment { get; set; }
    //    public string Name { get; set; }
    //    public string OriginalName { get; set; }
    //    public double? Popularity { get; set; }
    //    public string ProfilePath { get; set; }
    //    public string Character { get; set; }
    //    public string CreditId { get; set; }
    //    public int? Order { get; set; }
    //}

    public class CreatedBy
    {
        public int? Id { get; set; }
        public string CreditId { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public int? Gender { get; set; }
        public string ProfilePath { get; set; }
    }

    //public class Credits
    //{
    //    public List<Cast> Cast { get; set; }
    //    public List<Crew> Crew { get; set; }
    //}

    //public class Crew
    //{
    //    public bool? Adult { get; set; }
    //    public int? Gender { get; set; }
    //    public int? Id { get; set; }
    //    public string KnownForDepartment { get; set; }
    //    public string Name { get; set; }
    //    public string OriginalName { get; set; }
    //    public double? Popularity { get; set; }
    //    public string ProfilePath { get; set; }
    //    public string CreditId { get; set; }
    //    public string Department { get; set; }
    //    public string Job { get; set; }
    //}

    //public class Genre
    //{
    //    public int? Id { get; set; }
    //    public string Name { get; set; }
    //}

    public class LastEpisodeToAir
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public double? VoteAverage { get; set; }
        public int? VoteCount { get; set; }
        public string AirDate { get; set; }
        public int? EpisodeNumber { get; set; }
        public string EpisodeType { get; set; }
        public string ProductionCode { get; set; }
        public int? Runtime { get; set; }
        public int? SeasonNumber { get; set; }
        public int? ShowId { get; set; }
        public string StillPath { get; set; }
    }

    public class Network
    {
        public int? Id { get; set; }
        public string LogoPath { get; set; }
        public string Name { get; set; }
        public string OriginCountry { get; set; }
    }

    public class NextEpisodeToAir
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public int? VoteAverage { get; set; }
        public int? VoteCount { get; set; }
        public string AirDate { get; set; }
        public int? EpisodeNumber { get; set; }
        public string EpisodeType { get; set; }
        public string ProductionCode { get; set; }
        public object Runtime { get; set; }
        public int? SeasonNumber { get; set; }
        public int? ShowId { get; set; }
        public object StillPath { get; set; }
    }

    //public class ProductionCompany
    //{
    //    public int? Id { get; set; }
    //    public string LogoPath { get; set; }
    //    public string Name { get; set; }
    //    public string OriginCountry { get; set; }
    //}

    //public class ProductionCountry
    //{
    //    public string Iso31661 { get; set; }
    //    public string Name { get; set; }
    //}

    //public class Result
    //{
    //    public string Iso6391 { get; set; }
    //    public string Iso31661 { get; set; }
    //    public string Name { get; set; }
    //    public string Key { get; set; }
    //    public string Site { get; set; }
    //    public int? Size { get; set; }
    //    public string Type { get; set; }
    //    public bool? Official { get; set; }
    //    public DateTime? PublishedAt { get; set; }
    //    public string Id { get; set; }
    //}


    public class Season
    {
        public string AirDate { get; set; }
        public int? EpisodeCount { get; set; }
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public int? SeasonNumber { get; set; }
        public double? VoteAverage { get; set; }
    }

    //public class SpokenLanguage
    //{
    //    public string EnglishName { get; set; }
    //    public string Iso6391 { get; set; }
    //    public string Name { get; set; }
    //}

    //public class Videos
    //{
    //    public List<Result> Results { get; set; }
    //}



}
