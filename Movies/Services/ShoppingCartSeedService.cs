using System.Linq;
using Movies.Entities;

namespace Movies.Services
{
    public class ShoppingCartSeedService
    {
        public static void Seed()
        {
            using (var db = new DatabaseContext())
            {
                if (db.ShoppingCarts.Any())
                {
                    return;
                }

                var mainShoppingCart = new ShoppingCart();

                db.ShoppingCarts.Add(mainShoppingCart);

                db.SaveChanges();
            }
        }
    }
}