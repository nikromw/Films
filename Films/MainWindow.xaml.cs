using Films.dbFilms;
using Films.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Films
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BindingList<Film> _FilmList = new BindingList<Film>();
        private OmdbApi _searchRequest = new OmdbApi();
        public MainWindow()
        {
            InitializeComponent();
            using (var db = new FilmContext())
            {
                db.Database.Migrate();
            }
            this.Closed += MainWindow_Closed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgFilms.ItemsSource = _FilmList;
            _FilmList.ListChanged += _FilmList_ListChanged;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            SaveDb();
        }

        private void _FilmList_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemChanged:
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SearhField?.Text != "")
            {
                _searchRequest.SearcTtitle = SearhField?.Text;
                _searchRequest.RequestSearch();
                bool res = !_FilmList.Contains(_searchRequest.GetFilm);
                if (!Array.Exists<Film>(_FilmList.ToArray(), element => element.Title == _searchRequest.GetFilm.Title) && _searchRequest.GetFilm != null)
                {
                    _FilmList.Add(_searchRequest.GetFilm);
                    dgFilms.Items.Refresh();
                }
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Favorit_Button(object sender, RoutedEventArgs e)
        {
            SaveDb();
            FavoritesPage fv = new FavoritesPage();
            this.Content = fv;
        }

        private void SaveDb()
        {
            using (var db = new FilmContext())
            {
                try
                {
                    foreach (var film in _FilmList)
                    {
                        if (film.isFavorit)
                            db.Add(film);
                    }
                    db.SaveChanges();
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            foreach (var film in _FilmList)
            {
                if (film == dgFilms.SelectedItem)
                {
                    film.isFavorit = !film.isFavorit;
                }
            }
        }
    }
}
