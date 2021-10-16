using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Films.Annotations;
using Films.Commands;
using Films.DataBase;
using Films.Model;

namespace Films.ViewModel
{
    class FavoriteViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<Film> _favoriteFilms = new ObservableCollection<Film>();
        public Film SelectedFavoriteFilm { get; set; }
        private ICommand _deleteCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Film> FavoritesFilms
        {
            get => _favoriteFilms;
            set
            {
                _favoriteFilms = value;
                OnPropertyChanged("FavoritesFilms");
            }
        }

        public ICommand DeleteCommand
        {
            get => _deleteCommand;
        }

        public FavoriteViewModel()
        {
            FavoritesFilms = new ObservableCollection<Film>(DbHelper.GetAllFilms());
            _deleteCommand = new DelegateCommand<Film>(DeleteFromFavorite);
        }

        private void DeleteFromFavorite(Film film)
        {
            FavoritesFilms.Remove(film);
            DbHelper.DeleteFromDb(film);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
