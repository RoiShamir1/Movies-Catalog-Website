using System.ComponentModel.DataAnnotations;

namespace WebApplicationASP.Models
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }

        [Display(Name ="Total comments")]
        public int NumOfComments { get; set; }
    }
}
