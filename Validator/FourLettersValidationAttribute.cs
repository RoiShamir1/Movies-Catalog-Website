using System.ComponentModel.DataAnnotations;
using WebApplicationASP.Models;

namespace WebApplicationASP.Validator
{
    public class FourLettersValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var comment = (Comment)validationContext.ObjectInstance;
            return comment?.CommentText?.Length < 4 ? new ValidationResult("Please insert at least 4 characters") : ValidationResult.Success;
        }
    }
}
