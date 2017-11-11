using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Movies.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [Display(Name = "Production year")]
        public int ProductionYear { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public double Price { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}