using Microsoft.EntityFrameworkCore;
using WebApplicationASP.Models;

namespace WebApplicationASP.Data
{
    public class MyShopData : DbContext
    {
        public MyShopData(DbContextOptions<MyShopData> options) : base(options) { }

        public DbSet<Movie>? Movies { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<Category>? Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1,CategoryName = "Drama" },
                new Category { CategoryId = 2, CategoryName = "Action" },
                new Category { CategoryId = 3, CategoryName = "Thriller" },
                new Category { CategoryId = 4, CategoryName = "Comedy" }
                );
            modelBuilder.Entity<Movie>().HasData(
                new Movie { MovieId = 1, MovieName = "Inception", Year = 2010, CategoryId = 3, Description = "very good movie", ImageFile = "images/Inception_Poster_Israel.jpg" },
                new Movie { MovieId = 2, MovieName = "The Terminator", Year = 1984, CategoryId = 2, Description = "excellent movie", ImageFile = "images/250px-Terminator.jpg" },
                new Movie { MovieId = 3, MovieName = "The Dictator", Year = 2012, CategoryId = 4, Description = "funny movie", ImageFile = "images/The_Dictator_Poster.jpg" }
                );
            modelBuilder.Entity<Comment>().HasData(
                new Comment { CommentId = 1 , CommentText = "comment 1", MovieId = 1 },
                new Comment { CommentId = 2 , CommentText = "comment 2", MovieId = 1 },
                new Comment { CommentId = 3 , CommentText = "comment 3", MovieId = 1 },
                new Comment { CommentId = 4 , CommentText = "comment 4", MovieId = 2 },
                new Comment { CommentId = 5 , CommentText = "comment 5", MovieId = 2 },
                new Comment { CommentId = 6 , CommentText = "comment 6", MovieId = 3 }
                );

        }
    }
}
