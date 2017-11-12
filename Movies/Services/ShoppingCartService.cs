using System.Linq;
using Movies.Entities;
using Movies.Utils;
using Movies.ViewModels;

namespace Movies.Services
{
    public class ShoppingCartService
    {
        public static void AddMovie(DatabaseContext db, int id)
        {
            var movie = db.Movies.Find(id);

            var mainShoppingCart = db.ShoppingCarts.First();

            mainShoppingCart.Movies.Add(movie);
            db.SaveChanges();
        }

        public static void RemoveMovie(DatabaseContext db, int id)
        {
            var movie = db.Movies.Find(id);

            var mainShoppingCart = db.ShoppingCarts.First();

            mainShoppingCart.Movies.Remove(movie);
            db.SaveChanges();
        }

        public static ShoppingCartIndexViewModel GetAllByCategory(DatabaseContext db, string category)
        {
            var mainShoppingCart = db.ShoppingCarts.First();
            var movies = mainShoppingCart.Movies.AsQueryable();
                
            var viewModel = new ShoppingCartIndexViewModel
            {
                Movies = MovieHelper.GetMovies(movies, category),
                AvailableCategories = MovieHelper.GetCategories(movies).ToList(),
                SelectedCategory = category
            };

            return viewModel;
        }
    }
}