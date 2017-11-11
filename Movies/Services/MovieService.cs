using System.Linq;
using Movies.Entities;
using Movies.Utils;
using Movies.ViewModels;

namespace Movies.Services
{
    public class MovieService
    {
        public static Movie GetOneById(DatabaseContext db, int id)
        {
            return db.Movies.Find(id);
        }

        public static MoviesIndexViewModel GetAllByCategory(DatabaseContext db, string category)
        {
            var viewModel = new MoviesIndexViewModel
            {
                Movies = MovieHelper.GetMovies(db.Movies, category),
                AvailableCategories = MovieHelper.GetCategories(db.Movies).ToList(),
                SelectedCategory = category
            };

            return viewModel;
        }
    }
}