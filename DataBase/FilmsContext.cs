using System.Data.Entity;
using Films.Model;

namespace Films.DataBase
{
    class FilmsContext : DbContext
    {
        public FilmsContext() : base("DefaultConnection")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Film> Films { get; set; }
    }
}
