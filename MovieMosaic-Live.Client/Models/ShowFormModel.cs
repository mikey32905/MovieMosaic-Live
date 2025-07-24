using System.ComponentModel.DataAnnotations;

namespace MovieMosaic_Live.Client.Models
{
    public class ShowFormModel
    {
        [Required]
        public string? ShowTitle { get; set; }
        public string? FirstAiredDate { get; set; }
    }
}
