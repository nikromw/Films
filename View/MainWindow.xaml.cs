using System.Windows;
using Films.View;
using Films.ViewModel;

namespace Films
{
    public partial class MainWindow: Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Content = new SearchControl();
            this.DataContext = new SearchViewModel();
        }
    }
}
