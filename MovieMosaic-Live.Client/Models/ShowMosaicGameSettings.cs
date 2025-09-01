using System.ComponentModel.DataAnnotations;

namespace MovieMosaic_Live.Client.Models
{
    public class ShowMosaicGameSettings : IValidatableObject
    {
        [Required(ErrorMessage = "Please Select a start year")]
        public int YearStart { get; set; } = 2000;

        [Required(ErrorMessage = "Please Select an end year")]
        public int YearEnd { get; set; } = 2025; //Set to DateTimeNow year.

        public int SelectedGenre { get; set; } = 0;

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (YearEnd <= YearStart)
            {
                yield return new ValidationResult("End year must be greater than or equal to start year",
                    new[] { nameof(YearEnd), nameof(YearStart) });
            }
        }

    }
}
