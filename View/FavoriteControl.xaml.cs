using System.Windows;
using System.Windows.Controls;
using Films.ViewModel;

namespace Films.View
{
    public partial class FavoriteControl: UserControl
    {
        public FavoriteControl()
        {
            InitializeComponent();
        }

        private void GoToSearch(object sender, RoutedEventArgs e)
        {
            this.DataContext = new SearchViewModel();
            this.Content = new SearchControl();
        }
    }
}
