using System.Collections.Generic;
using System.Linq;
using Films.Model;

namespace Films.DataBase
{
    class DbHelper
    {
        public static List<Film> GetAllFilms()
        {
            using (var db = new FilmsContext())
            {
                return db.Films.ToList();
            }
        }

        public static void SaveFavoriteFilm(Film favoriteFilm)
        {
            using(var db = new FilmsContext())
            {
                db.Films.Add(favoriteFilm);
                db.SaveChanges();
            }
        }
    }
}
