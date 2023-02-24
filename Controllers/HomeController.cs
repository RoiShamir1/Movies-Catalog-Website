using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using WebApplicationASP.Models;
using WebApplicationASP.Repositories;

namespace WebApplicationASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        private readonly ILogger<HomeController> _logger;

        public HomeController (IRepository repository, ILogger <HomeController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {
            var model = await _repository.GetPopularMovies(2);
            return View(model);
        }

        public async Task<ActionResult> Details(int id)
        {
            var model = await _repository.GetOneMovie(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CommentAdd(Comment comment)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddComment(comment);              
            }
            return RedirectToAction("Details", new { id = comment.MovieId });
        }

        //[HttpPost]
        //public async Task<ActionResult> CommentAdd(int movieId, string commentText)
        //{
        //    if (commentText.Length < 3)
        //    {
        //        ModelState.AddModelError("CommentText", "Comment text must be at least 3 characters");
        //        return View("Details", _repository.GetOneMovie(movieId));
        //    }

        //    Comment comment = new Comment()
        //    {
        //        MovieId = movieId,
        //        CommentText = commentText
        //    };

        //    await _repository.AddComment(comment);
        //    return RedirectToAction("Details", new { id = comment.MovieId });
        //}
    }
}
