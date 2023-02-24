using System.ComponentModel.DataAnnotations;
using WebApplicationASP.Validator;

namespace WebApplicationASP.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter category name.")]
        [LettersOnlyValidation(ErrorMessage = "only letters are allowed!")]
        public string? CategoryName { get; set; }
    }
}