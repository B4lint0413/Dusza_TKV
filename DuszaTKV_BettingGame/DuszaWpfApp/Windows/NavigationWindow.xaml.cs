using System.Windows;
using System.Windows.Controls;
using DuszaTKVGameLib;
using DuszaWpfApp.UserControls;

namespace DuszaWpfApp.Windows;

public partial class NavigationWindow : Window
{
    private readonly User _user;
    public NavigationWindow(User user)
    {
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
        InitializeComponent();
        _user = user;

        UserHeader header = new UserHeader(user);
        Container.Children.Add(header);
        Grid.SetRow(header, 0);
    }

    private void SwitchAccount(object sender, RoutedEventArgs e)
    {
        new LogInWindow().Show();
        Close();
    }

    private void CreateGame(object sender, RoutedEventArgs e)
    {
        new CreateNewGameWindow(_user).Show();
        Close();
    }

    private void CheckOrganizedGames(object sender, RoutedEventArgs e)
    {
        new AdminGameWindow(_user).Show();
        Close();
    }

    private void OpenBetWindow(object sender, RoutedEventArgs e)
    {
        new BetWindow(_user).Show();
        Close();
    }

    private void OpenPlacedBetWindow(object sender, RoutedEventArgs e)
    {
        new PlacedBets(_user).Show();
        Close();
    }

    private void OpenLeaderboard(object sender, RoutedEventArgs e)
    {
        new LeaderboardWindow(_user).Show();
        Close();
    }
}