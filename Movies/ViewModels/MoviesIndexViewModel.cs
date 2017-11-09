using System.Collections.Generic;
using System.Web.Mvc;
using Movies.Entities;

namespace Movies.ViewModels
{
    public class MoviesIndexViewModel
    {
        public Movie Header => new Movie();
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<SelectListItem> AvailableCategories { get; set; }
        public string SelectedCategory { get; set; }
    }
}