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
using System.Windows.Threading;

namespace Films
{
    /// <summary>
    /// Interaction logic for SeachControl.xaml
    /// </summary>
    public partial class SeachControl : UserControl
    {
        private BindingList<Film> _FilmList = new BindingList<Film>();
        private OmdbApi _searchRequest = new OmdbApi();
        public SeachControl()
        {
            InitializeComponent();
            dgFilms.ItemsSource = _FilmList;
            using (var db = new FilmContext())
            {
                db.Database.Migrate();
            }
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
            _searchRequest.GetFilm.isFavorit = !_searchRequest.GetFilm.isFavorit;
        }
    }
    public static class ExtensionMethods
    {

        private static Action EmptyDelegate = delegate () { };


        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
}

