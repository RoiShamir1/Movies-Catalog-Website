using System.ComponentModel.DataAnnotations;

namespace WebApplicationASP.Validator
{
    public class LettersOnlyValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return value != null && ((string)value).All(char.IsLetter);
        }
    }
}
