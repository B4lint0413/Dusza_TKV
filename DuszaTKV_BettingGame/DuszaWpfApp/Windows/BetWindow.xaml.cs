using System.Windows;
using System.Windows.Controls;
using DuszaTKVGameLib;
using DuszaWpfApp.UserControls;

namespace DuszaWpfApp.Windows
{
    /// <summary>
    /// Interaction logic for BetWindow.xaml
    /// </summary>
    public partial class BetWindow : Window
    {
        private readonly User _user;
        public BetWindow(User user)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            var header = new UserHeader(user);
            MainContainer.Children.Add(header);
            Grid.SetRow(header, 0);

            _user = user;
        }

        private void ToNavigationWindow(object sender, RoutedEventArgs e)
        {
            new NavigationWindow(_user).Show();
            Close();
        }
    }
}
