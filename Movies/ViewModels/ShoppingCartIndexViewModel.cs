using System.Linq;

namespace Movies.ViewModels
{
    public class ShoppingCartIndexViewModel : MoviesIndexViewModel
    {
        public int MoviesCount => Movies.Count();

        public double MoviesTotalPrice => Movies.Sum(movie => movie.Price);
    }
}