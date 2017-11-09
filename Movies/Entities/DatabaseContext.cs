using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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
