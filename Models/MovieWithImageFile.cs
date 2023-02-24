namespace WebApplicationASP.Models
{
    public class MovieWithImageFile
    {
        public Movie? Movie { get; set; }
        public IFormFile? PictureFile { get; set; }
    }
}
