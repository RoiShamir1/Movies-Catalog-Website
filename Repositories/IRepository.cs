using WebApplicationASP.Models;

namespace WebApplicationASP.Repositories
{
    public interface IRepository
    {
        Task<List<Movie>> GetMovies();
        Task<Movie> GetOneMovie(int id);
        Task<List<MovieViewModel>> GetPopularMovies(int count);
        Task<List<Movie>> MoviesByCategory(int categoryId = 1);
        Task AddMovie(Movie movie);
        Task UpdateMovie(Movie movie);
        Task DeleteMovie(int id);

        //IEnumerable<Comment> GetComments();
        Task AddComment(Comment comment);
        //void UpdateComment(Comment comment);
        //void DeleteComment(int id);

         Task<List<Category>> GetCategories();

    }
}
