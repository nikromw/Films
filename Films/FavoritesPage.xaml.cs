using Films.dbFilms;
using Films.Models;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for FavoritesPage.xaml
    /// </summary>
    public partial class FavoritesPage : UserControl
    {

        public List<Film> filmsFromDb = new List<Film>();

        public FavoritesPage()
        {
            
            InitializeComponent();

            using (var db = new FilmContext())
            {
                var content = from f in db.Films select f;
                foreach (var item in content)
                {
                    Film a = new Film(item);
                    filmsFromDb.Add(item);
                }
            }
            filmsList.ItemsSource = filmsFromDb;
        }

        private void filmsList_selection(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Check(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new FilmContext())
            {
                var a = e.RoutedEvent.HandlerType;
                db.Films.Remove((Film)filmsList.DataContext);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content =new SeachControl();
        }
    }
}
