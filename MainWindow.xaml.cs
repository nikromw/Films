using System;
using System.Windows;
using Films.ViewModel;

namespace Films
{
    public partial class MainWindow: Window
    {
        public MainWindow()
        {
            this.DataContext = new MainWindowViewModel();
            InitializeComponent();
        }

        private void CloseWindow(object sender, EventArgs e)
        { }

        private void GoToFavorite(object sender, RoutedEventArgs e)
        {
            this.DataContext = new FavoriteViewModel();
        }
    }
}
