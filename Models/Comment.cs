using System.ComponentModel.DataAnnotations;
using WebApplicationASP.Validator;

namespace WebApplicationASP.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        [Required(ErrorMessage = "Please do not insert an empty comment.")]
        [LettersOnlyValidation(ErrorMessage = "only letters are allowed!")]
        [FourLettersValidation(ErrorMessage = "Please insert at least 4 characters")]
        public string? CommentText { get; set; }

        public int MovieId { get; set; }
        public virtual Movie? Movie { get; set; }
    }
}
