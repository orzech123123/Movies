using System.Data.Entity;

namespace Movies.Entities
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DatabaseContext() : base("name=DatabaseContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DatabaseContext>()); 
        }
    }
}
