using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Films.Annotations;
using Films.Commands;
using Films.Model;

namespace Films.ViewModel
{
    class SearchViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<Film> _films = new ObservableCollection<Film>();
        private ICommand _searchCommand;
        public event PropertyChangedEventHandler PropertyChanged;
        private OmdbApi _searchRequest = new OmdbApi();

        public ICommand SearchCommand
        {
            get => _searchCommand;
        }

        public ObservableCollection<Film> Films
        {
            get => _films;
            set
            {
                _films = value;
                OnPropertyChanged("Films");
            }
        }

        public SearchViewModel()
        {
            _searchCommand = new DelegateCommand<string>(Search);
        }

        private void Search(string filmName)
        {
            if (string.IsNullOrEmpty(filmName))
                return;
            
            _searchRequest.RequestSearch(filmName);

            if (Films.Any(film => film.Title == filmName))
                return;

            if (_searchRequest.GetFilm != null)
                _films.Add(_searchRequest.GetFilm);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
