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
                return new ValidationResult("Please upload at least 1 Thumbnail.");
            }

            if (thumbnails.Any(t => !(t.ContentType.Contains("jpeg") || t.ContentType.Contains("jpg"))))
            {
                return new ValidationResult("Only jpeg's are currently accepted.");
            }

            return ValidationResult.Success;
        }
    }
}