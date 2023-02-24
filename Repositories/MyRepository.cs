using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using WebApplicationASP.Data;
using WebApplicationASP.Models;

namespace WebApplicationASP.Repositories
{
    public class MyRepository : IRepository
    {
        private readonly MyShopData _context;


        public MyRepository(MyShopData context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetMovies()
        {
            var result = await _context.Movies!.ToListAsync();
            return result;

            //var result = await _context.Movies!.Include( m => m.Category).AsEnumerable();
            //return result;
        }

        public async Task<Movie> GetOneMovie(int id)
        {
            var movie = await _context.Movies!.Where( m => m.MovieId == id).FirstOrDefaultAsync();
            return movie!;
        }

        public async Task<List<MovieViewModel>> GetPopularMovies(int count)
        {
            var list = await _context.Movies!.Include( a => a.Category)
            .Select(movie => new MovieViewModel { Movie = movie, NumOfComments = movie.Comments!.Count(),})
            .OrderByDescending( a => a.NumOfComments).Take(count).ToListAsync();

            return list;
        }

        public async Task AddMovie(Movie movie)
        {
            _context.Movies!.Add(movie);
            _context.SaveChanges();
        }

        public async Task UpdateMovie(Movie movie)
        {
            //var mov = _context.Movies?.SingleOrDefault(m => m.MovieId == movie.MovieId);
            if (movie != null)
            {
                 _context.Movies!.Update(movie);
            }
            //_context.Update(movie);

            _context.SaveChanges();
        }

        public async Task DeleteMovie(int id)
        {
            var movie =  _context.Movies?.SingleOrDefault(m => m.MovieId == id);
            if (movie != null)
            {
                 _context.Movies!.Remove(movie);
            }
            _context.SaveChanges();
        }

        //public IEnumerable<Comment> GetComments()
        //{
        //    var result = _context.Comments!.Include( c => c.Movie).AsEnumerable();
        //    return result;
        //    //return _context.Comments!;
        //}

        public async Task<List<Category>> GetCategories()
        {
            var result = await _context.Categories!.ToListAsync();
            return result!;
        }

        public async Task AddComment(Comment comment)
        {
            
            _context.Comments!.Add(comment);
            _context.SaveChanges();
        }

        public async Task<List<Movie>> MoviesByCategory(int categoryId = 1)
        {
            var result = await _context.Movies!.Where( m => m.CategoryId == categoryId).ToListAsync();
            return result;
        }
    }
}
