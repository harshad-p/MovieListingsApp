using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MovieListingsApp.Models.MovieModels.ValidationAttributes
{
    internal class ValidateActors : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (CreateViewModel)validationContext.ObjectInstance;

            var actors = model.Actors;

            if (!actors.Any())
            {
                return new ValidationResult("Please select atleast 1 Actor.");
            }

            return ValidationResult.Success;
        }
    }
}