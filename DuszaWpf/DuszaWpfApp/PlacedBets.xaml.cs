using DuszaTKVGameLib;
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
using System.Windows.Shapes;

namespace DuszaWpfApp
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

            foreach (var bet in App.Users[player.Name].PlacedBets.AllBets)
            {
                Scroller.Children.Add(new PlacedBet(bet));
            }

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
