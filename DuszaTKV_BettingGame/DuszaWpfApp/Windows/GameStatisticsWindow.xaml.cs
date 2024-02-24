using System.Windows;
using System.Windows.Controls;
using DuszaTKVGameLib;
using DuszaWpfApp.UserControls;

namespace DuszaWpfApp.Windows;

public partial class GameStatisticsWindow : Window
{
    private readonly User _user;
    public GameStatisticsWindow(User user)
    {
        InitializeComponent();
        var header = new UserHeader(user);
        MainContainer.Children.Add(header);
        Grid.SetRow(header, 0);
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
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