using System.ComponentModel.DataAnnotations;
using WebApplicationASP.Validator;

namespace WebApplicationASP.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Please enter movie name.")]
        [LettersOnlyValidation(ErrorMessage = "only letters are allowed!")]
        public string? MovieName { get; set; }

        [Required(ErrorMessage = "Please enter year.")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Please enter description.")]
        [LettersOnlyValidation(ErrorMessage = "only letters are allowed!")]
        [ValidMovie(ErrorMessage = "Please insert at least 4 characters")]
        public string? Description { get; set;}

        [Required(ErrorMessage = "Please enter a CategoryId.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter a Url photo.")]
        public string? ImageFile { get; set; }
        public virtual Category? Category { get; set; }

        //[Required(ErrorMessage ="Please enter comment")]
        //[ValidComment(ErrorMessage ="please insert at least 4 characters")]
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
