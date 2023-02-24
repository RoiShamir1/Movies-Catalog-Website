using System.ComponentModel.DataAnnotations;
using WebApplicationASP.Models;

namespace WebApplicationASP.Validator
{
    public class ValidCommentAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var comment = (Comment)validationContext.ObjectInstance;
            return comment?.CommentText?.Length < 3 ? new ValidationResult("Please insert at least 3 characters") : ValidationResult.Success;
        }
    }
}
