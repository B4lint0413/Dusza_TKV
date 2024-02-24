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
            foreach (var game in App.Games.GetOwnGames(organizer.Name))
                GameCardContainer.Children.Add(new EndGameCard(game, organizer));
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
