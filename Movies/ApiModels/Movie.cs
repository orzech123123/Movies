using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Movies.ApiModels
{
    public class MovieCollection
    {
        public IList<Movie> Results { get; set; }
    }

    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Overview { get; set; }

        [JsonProperty("release_date")]
        public DateTime? ReleaseDate { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }
    }
}