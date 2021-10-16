using System.ComponentModel;
using System.Windows.Input;
using Films.Commands;
using Films.DataBase;

namespace Films.Model
{
    class Film
    {
        public int Id { get; set; }
        public string Runtime { get; set; }
        public string Poster { get; set; }
        public string Genre { get; set; }
        public string Writer { get; set; }
        public int YearOfFilm { get; set; }
        public string Title { get; set; }
        private ICommand _favoriteCommand;

        public ICommand FavoriteCommand
        {
            get => _favoriteCommand;
        }

        public Film()
        {
            _favoriteCommand = new DelegateCommand<Film>(SaveFavoriteInDb);
        }

        private void SaveFavoriteInDb(Film film)
        {
            DbHelper.SaveFavoriteFilm(film);
        }
    }
}
