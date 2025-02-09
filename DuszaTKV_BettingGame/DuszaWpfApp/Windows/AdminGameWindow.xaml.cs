using System.Windows;
using System.Windows.Controls;
using DuszaTKVGameLib;
using DuszaWpfApp.UserControls;

namespace DuszaWpfApp.Windows
{
    public partial class AdminGameWindow
    {
        private readonly User _organizer;
        public AdminGameWindow(User organizer)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            var header = new UserHeader(organizer);
            MainContainer.Children.Add(header);
            Grid.SetRow(header, 0);_organizer = organizer;
        }
        
        private void CreateNewGame(object sender, RoutedEventArgs e)
        {
            new CreateNewGameWindow(_organizer).Show();
            Close();
        }

        private void ToNavigationWindow(object sender, RoutedEventArgs e)
        {
            new NavigationWindow(_organizer).Show();
            Close();
        }
    }
}
