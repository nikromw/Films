using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
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
        private ICommand _favoriteCommand;

        public ICommand FavoriteCommand
        {
            get => _favoriteCommand;
        }

        public bool CanExecuteFavorite
        {
            get => _favoriteCommand == null;
        }

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
            _favoriteCommand = new DelegateCommand<string>(MakeFavorite);
        }

        private void Search(string filmName)
        {
            if(string.IsNullOrEmpty(filmName))
                return;

            _searchRequest.SearcTtitle = filmName;
            _searchRequest.RequestSearch();
            bool res = !_films.Any(film =>film.Title == _searchRequest.GetFilm.Title);

            if (Films.Any(film => film.Title == filmName))
                return;

            _films.Add(_searchRequest.GetFilm);
        }

        //добавление в любимых
        private void MakeFavorite(string filmName)
        {
            //SaveDb();
            //FavoritesPage fv = new FavoritesPage();
            //this.Content = fv;
        }

        //private void SaveDb()
        //{
        //    using(var db = new FilmContext())
        //    {
        //        try
        //        {
        //            foreach(var film in _FilmList)
        //            {
        //                if(film.isFavorit)
        //                    db.Add(film);
        //            }
        //            db.SaveChanges();

        //        }
        //        catch(Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //        }
        //    }
        //}

        //private void CheckBox_Click(object sender, RoutedEventArgs e)
        //{
        //    foreach(var film in _films)
        //    {
        //        if(film == dgFilms.SelectedItem)
        //        {
        //            film.isFavorit = !film.isFavorit;
        //        }
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
