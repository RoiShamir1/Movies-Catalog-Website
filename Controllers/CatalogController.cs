using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplicationASP.Data;
using WebApplicationASP.Models;
using WebApplicationASP.Repositories;

namespace WebApplicationASP.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IRepository _repository;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(ILogger<CatalogController> logger , IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<ActionResult> Index([FromQuery] int id = 1)
        {
            //Task<List<Movie>> movies = await _repository.MoviesByCategory(categoryId);

            var movies = await _repository.MoviesByCategory(id);

            ViewBag.CategoryId = new SelectList(await _repository.GetCategories(), "CategoryId", "CategoryName");
            return View(movies);
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
            return RedirectToAction("Details", new {id = comment.MovieId});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}