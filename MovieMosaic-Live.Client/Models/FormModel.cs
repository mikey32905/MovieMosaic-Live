using System.ComponentModel.DataAnnotations;

namespace MovieMosaic_Live.Client.Models
{
    public class FormModel
    {
        [Required]
        public string? MovieTitle { get; set; }
        public string? ReleaseDate { get; set; }
    }
}
