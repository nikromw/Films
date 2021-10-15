using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Films.Annotations;
using Films.Commands;
using Films.DataBase;
using Films.Model;

namespace Films.ViewModel
{
    class MainWindowViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<Film> _films = new ObservableCollection<Film>();
        private ICommand _searchCommand;

        public ICommand SearchCommand
        {
            get => _searchCommand;
        }

        public bool CanExecuteSearch
        {
            get => _searchCommand == null;
        }

        public ObservableCollection<Film> Films
        {
            get
            {
                return _films;
            }
            set
            {
                _films = value;
                OnPropertyChanged("Films");
            }
        }

        private OmdbApi _searchRequest = new OmdbApi();

        public MainWindowViewModel()
        {
            _films = new ObservableCollection<Film>(DbHelper.GetAllFilms());
            _searchCommand = new DelegateCommand<string>(Search);
        }

        private void Search(string filmName)
        {
            if(string.IsNullOrEmpty(filmName))
                return;

            _searchRequest.SearcTtitle = filmName;
            _searchRequest.RequestSearch();
            bool res = !_films.Any(film => film.Title == _searchRequest.GetFilm.Title);

            if(Films.Any(film => film.Title == filmName))
                return;

            _films.Add(_searchRequest.GetFilm);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
