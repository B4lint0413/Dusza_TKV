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
            UserHeader header = new UserHeader(user);
            MainContainer.Children.Add(header);
            Grid.SetRow(header, 0);

            _user = user;
            foreach (Game game in App.Games.GetBettableGames(user.Name))
            {
                BetCardContainer.Children.Add(new BetCard(user, game));
            }
        }

        private void ToNavigationWindow(object sender, RoutedEventArgs e)
        {
            new NavigationWindow(_user).Show();
            Close();
        }
    }
}
