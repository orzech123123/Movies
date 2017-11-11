using System;
using System.Linq;
using Movies.Entities;
using NLipsum.Core;

namespace Movies.Services
{
    public class MovieSeedService
    {
        public static void Seed()
        {
            using (var db = new DatabaseContext())
            {
                if (db.Movies.Any())
                {
                    return;
                }

                var random = new Random(Guid.NewGuid().GetHashCode());

                var genreCollection = ApiService.GetGenres();

                foreach (var genre in genreCollection.Genres)
                {
                    var movieCollection = ApiService.GetMovies(genre.Id);

                    foreach (var movie in movieCollection.Results)
                    {
                        if (!db.Movies.Any(m => m.Title == movie.Title))
                        {
                            db.Movies.Add(new Movie
                            {
                                Title = movie.Title,
                                Category = genre.Name,
                                Description = !string.IsNullOrWhiteSpace(movie.Overview) ? movie.Overview : LipsumGenerator.Generate(10),
                                Price = random.Next(10, 200),
                                ProductionYear = movie.ReleaseDate?.Year ?? random.Next(1990, 2018),
                                ImageUrl = !string.IsNullOrWhiteSpace(movie.PosterPath) ? $"https://image.tmdb.org/t/p/w500{movie.PosterPath}" : null
                            });
                        }
                    }
                }

                db.SaveChanges();
            }
        }
    }
}