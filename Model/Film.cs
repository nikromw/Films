using System.ComponentModel;
using System.Windows.Input;
using Films.Commands;
using Films.DataBase;

namespace Films.Model
{
    class Film: INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Runtime { get; set; }
        public string Poster { get; set; }
        public string Genre { get; set; }
        public string Writer { get; set; }
        public int YearOfFilm { get; set; }
        public string Title { get; set; }
        private ICommand _favoriteCommand;
        private ICommand _deleteCommand;

        public Film()
        {
            _favoriteCommand = new DelegateCommand<Film>(SaveFavoriteInDb);
        }

        private void SaveFavoriteInDb(Film film)
        {
            DbHelper.SaveFavoriteFilm(film);
        }

        private void DeleteFromFavorite(Film film)
        {
            DbHelper.DeleteFromDb(film);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
