using System.Windows;
using DuszaTKVGameLib;

namespace DuszaWpfApp;

public partial class NavigationWindow : Window
{
    private readonly User _user;
    public NavigationWindow(User user)
    {
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
        InitializeComponent();
        _user = user;
    }

    private void SwitchAccount(object sender, RoutedEventArgs e)
    {
        new SignUpWindow().Show();
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
}