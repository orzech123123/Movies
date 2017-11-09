using System.Collections.Generic;

namespace Movies.ApiModels
{
    public class GenreCollection
    {
        public IList<Genre> Genres { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}