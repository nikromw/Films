using System.Windows;
using System.Windows.Controls;
using Films.ViewModel;

namespace Films.View
{
    public partial class SearchControl: UserControl
    {
        public SearchControl()
        {
            InitializeComponent();
        }
        private void GoToFavorite(object sender, RoutedEventArgs e)
        {
            this.Content = new FavoriteControl();
            this.DataContext = new FavoriteViewModel();
        }
    }
}
