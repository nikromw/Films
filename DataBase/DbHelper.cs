using System.Collections.Generic;
using System.Linq;
using Films.Model;

namespace Films.DataBase
{
    class DbHelper
    {
        public static List<Film> GetAllFilms()
        {
            using(var db = new FilmsContext())
            {
                return db.Films.ToList();
            }
        }

        public static void SaveFavoriteFilm(Film favoriteFilm)
        {
            using(var db = new FilmsContext())
            {
                if(db.Films.Count(film => film.Title == favoriteFilm.Title) == 0)
                    db.Films.Add(favoriteFilm);

                db.SaveChanges();
            }
        }

        public static void DeleteFromDb(Film favoriteFilm)
        {
            using(var db = new FilmsContext())
            {
                var deletedFilm = db.Films.FirstOrDefault(film => film.Title == favoriteFilm.Title);

                if (deletedFilm != null)
                    db.Films.Remove(deletedFilm);

                db.SaveChanges();
            }
        }
    }
}
