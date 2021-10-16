using System.Data.Entity;
using Films.Model;

namespace Films.DataBase
{
    class FilmsContext : DbContext
    {
        public FilmsContext() : base("FilmsDB")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Film> Films { get; set; }
    }
}
