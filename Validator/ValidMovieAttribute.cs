using System.ComponentModel.DataAnnotations;
using WebApplicationASP.Models;

namespace WebApplicationASP.Validator
{
    public class ValidMovieAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            return movie?.Description?.Length < 4 ? new ValidationResult("Please insert at least 4 characters") : ValidationResult.Success;
        }
    }
}
