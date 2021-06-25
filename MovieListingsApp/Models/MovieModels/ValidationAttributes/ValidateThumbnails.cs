using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MovieListingsApp.Models.MovieModels.ValidationAttributes
{
    internal class ValidateThumbnails : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (CreateViewModel)validationContext.ObjectInstance;

            var thumbnails = model.Thumbnails;

            if (!thumbnails.Any() || thumbnails.Any(t => t == null))
            {
                return new ValidationResult("Please upload atleast 1 Thumbnail.");
            }

            return ValidationResult.Success;
        }
    }
}