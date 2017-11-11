using System.Web.Mvc;
using Movies.Entities;
using Movies.Services;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly DatabaseContext _db = new DatabaseContext();

        [HttpGet]
        public ActionResult Index(string category)
        {
            var viewModel = MovieService.GetAllByCategory(_db, category);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection, string selectedCategory)
        {
            return RedirectToAction("Index", new { category = selectedCategory });
        }
        
        public ActionResult Details(int id)
        {
            var movie = MovieService.GetOneById(_db, id);
            
            return View(movie);
        }
    }
}
