using Films.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.dbFilms
{
    class FilmContext: DbContext
    {
        public DbSet<Film> Films { get; set; }

        public FilmContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Film.db"); 
        }
    }
}
