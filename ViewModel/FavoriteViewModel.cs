using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Films.DataBase;
using Films.Model;

namespace Films.ViewModel
{
    class FavoriteViewModel
    {
        public List<Film> FavoritesFilms { get; set; } = new List<Film>();

        public FavoriteViewModel()
        {
            FavoritesFilms = new List<Film>(DbHelper.GetAllFilms());
        }
    }
}
