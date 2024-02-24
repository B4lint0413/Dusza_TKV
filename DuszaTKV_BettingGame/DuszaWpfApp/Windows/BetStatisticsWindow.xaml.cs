using System.Windows;
using System.Windows.Controls;
using DuszaTKVGameLib;
using DuszaWpfApp.UserControls;

namespace DuszaWpfApp.Windows;

public partial class BetStatisticsWindow : Window
{
    private readonly User _user;
    public BetStatisticsWindow(User user, Game game)
    {
        InitializeComponent();
        _user = user;
        var header = new UserHeader(user);
        MainContainer.Children.Add(header);
        Grid.SetRow(header, 0);

        foreach (var e in game.Events)
            Container.Children.Add(new BetStatisticsCard(e));
    }

    private void ToNavigationWindow(object sender, RoutedEventArgs e)
    {
        new NavigationWindow(_user).Show();
        Close();
    }
}