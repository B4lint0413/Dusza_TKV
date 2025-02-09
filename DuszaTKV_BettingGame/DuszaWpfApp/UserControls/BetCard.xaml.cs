using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DuszaTKVGameLib;
using DuszaWpfApp.Windows;

namespace DuszaWpfApp.UserControls
{
    /// <summary>
    /// Interaction logic for BetCard.xaml
    /// </summary>
    public partial class BetCard : UserControl
    {
        private Game currentGame;
        private User player;
        public BetCard(User user, Game game)
        {
            InitializeComponent();
            currentGame = game;
            player = user;
        }

        private void MakeBetWindow(object sender, RoutedEventArgs e)
        {
            new MakeBetWindow(player, currentGame).Show();
            Window.GetWindow(Parent)!.Close();
        }
    }
}
