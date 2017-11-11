using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Movies.Entities;

namespace Movies.Utils
{
    public class MovieHelper
    {
        public static IEnumerable<Movie> GetMovies(IQueryable<Movie> movies, string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return movies
                    .Include(
                        movie => movie.ShoppingCarts
                            .Select(cart => cart.Movies)
                    )
                    .ToList();
            }

            return movies
                .Where(movie => movie.Category == category)
                .Include(
                    movie => movie.ShoppingCarts
                        .Select(cart => cart.Movies)
                )
                .ToList();
        }

        public static IEnumerable<SelectListItem> GetCategories(IQueryable<Movie> movies)
        {
            var categories = movies.Select(movie => movie.Category).Distinct();

            yield return new SelectListItem
            {
                Text = "-- Choose category -- ",
                Value = string.Empty
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