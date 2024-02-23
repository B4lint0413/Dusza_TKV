using System.Windows;
using System.Windows.Controls;
using DuszaTKVGameLib;
using DuszaWpfApp.UserControls;

namespace DuszaWpfApp.Windows
{
    /// <summary>
    /// Interaction logic for PlacedBets.xaml
    /// </summary>
    public partial class PlacedBets : Window
    {
        private User player;
        public PlacedBets(User player)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            this.player = player;

            foreach (var bet in App.Users[player.Name].PlacedBets.Items)
                Scroller.Children.Add(new PlacedBet(bet));

            UserHeader header = new UserHeader(player);
            MainContainer.Children.Add(header);
            Grid.SetRow(header, 0);
        }

        private void ToNavigationWindow(object sender, RoutedEventArgs e)
        {
            new NavigationWindow(player).Show();
            Close();
        }
    }
}
