using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Movies.Entities;
using Movies.ViewModels;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly DatabaseContext _db = new DatabaseContext();
        
        [HttpGet]
        public ActionResult Index(string category)
        {
            var viewModel = new MoviesIndexViewModel
            {
                Movies = GetMovies(category),
                AvailableCategories = GetCategories(),
                SelectedCategory = category
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection, string selectedCategory)
        {
            return RedirectToAction("Index", new { category = selectedCategory });
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var movie = _db.Movies.Find(id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }

        private IEnumerable<Movie> GetMovies(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return _db.Movies.ToList();
            }

            return _db.Movies.Where(movie => movie.Category == category).ToList();
        }

        private IEnumerable<SelectListItem> GetCategories()
        {
            var categories = _db.Movies.Select(movie => movie.Category).Distinct();

            yield return new SelectListItem
            {
                Text = "-- Choose category -- "
            };

            foreach (var category in categories)
            {
                yield return new SelectListItem
                {
                    Text = category,
                    Value = category
                };
            }
        }
    }
}
