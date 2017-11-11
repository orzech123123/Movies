using System.Collections.Generic;

namespace Movies.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}