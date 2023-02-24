using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationASP.Data;
using WebApplicationASP.Models;
using WebApplicationASP.Repositories;

namespace WebApplicationASP.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepository _repository;

        private readonly ILogger<AdminController> _logger;

        private readonly IWebHostEnvironment _environment;

        public AdminController(IRepository repository, ILogger<AdminController> logger, IWebHostEnvironment environment)
        {
            _repository = repository;
            _logger = logger;
            _environment = environment;
        }

        // GET: AdminController
        public ActionResult Index()
        {
            Task<List<Movie>> movies = _repository.GetMovies();
            return View(movies);
        }

        //GET: AdminController/Create

        [HttpGet]
        public async Task<ActionResult> CreateMovie(Movie movie)
        {
            ViewBag.CategoryId = new SelectList(await _repository.GetCategories(), "CategoryId", "CategoryName");


            //int[] arr = { 1, 2, 3 };

            //ViewBag.Ids = arr;
            return View();
         
        }

        //[HttpPost]
        //public async Task<ActionResult> Create(MovieWithImageFile movie, IFormFile? pictureFile)
        //{
        //    if (pictureFile == null || pictureFile.Length == 0)
        //    {
        //        return Content("File not selected");
        //    }
        //    var path = Path.Combine(_e)


        //    await _repository.AddMovie(movie);
        //    return RedirectToAction(nameof(Index));

        //}

        [HttpPost]
        public async Task<ActionResult> Create (Movie model, IFormFile? pictureFile)
        {
            if (pictureFile == null || pictureFile.Length == 0)
            {
                return Content("File not selected");
            }
            var path = Path.Combine(_environment.WebRootPath, "images", pictureFile.FileName);
            await using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await pictureFile.CopyToAsync(stream);
                stream.Close();
            }
            if (model != null)
            {
                model!.ImageFile = "images/" + pictureFile.FileName;
                await _repository.AddMovie(model);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> EditMovie(int id)
        {
            ViewBag.CategoryId = new SelectList(await _repository.GetCategories(), "CategoryId", "CategoryName");

            var movie = await _repository.GetOneMovie(id);
            return View(movie);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Movie model, IFormFile? pictureFile)
        {
            if (pictureFile != null && pictureFile.Length != 0)
            {
                var path = Path.Combine(_environment.WebRootPath, "images", pictureFile.FileName);
                await using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await pictureFile.CopyToAsync(stream);
                    stream.Close();
                }
                model!.ImageFile = "images/" + pictureFile.FileName;
            }
            await _repository.UpdateMovie(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            var movie = await _repository.GetOneMovie(id);
            return View(movie);
        }

        //[HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.DeleteMovie(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
