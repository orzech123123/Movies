using System.Data.Entity;

namespace Movies.Entities
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DatabaseContext() : base("name=DatabaseContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DatabaseContext>()); 
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(s => s.ShoppingCarts)
                .WithMany(c => c.Movies)
                .Map(cs =>
                {
                    cs.MapLeftKey("Movie_Id");
                    cs.MapRightKey("ShoppingCart_Id");
                    cs.ToTable("MovieShoppingCarts");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
