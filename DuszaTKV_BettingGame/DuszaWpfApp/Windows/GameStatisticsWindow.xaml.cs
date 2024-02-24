using System.Windows;
using DuszaTKVGameLib;
using DuszaWpfApp.UserControls;

namespace DuszaWpfApp.Windows;

public partial class GameStatisticsWindow : Window
{
    private readonly User _user;
    public GameStatisticsWindow(User user)
    {
        InitializeComponent();
        _user = user;
        foreach (var game in App.Games.Items)
            Container.Children.Add(new GameStatisticsCard(game));
    }

    private void ToNavigationWindow(object sender, RoutedEventArgs e)
    {
        new NavigationWindow(_user).Show();
        Close();
    }
}