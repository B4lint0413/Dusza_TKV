using System.Windows;
using System.Windows.Controls;
using DuszaTKVGameLib;
using DuszaWpfApp.UserControls;

namespace DuszaWpfApp.Windows;

public partial class BetStatisticsGameWindow : Window
{
    private readonly User _user;
    public BetStatisticsGameWindow(User user)
    {
        InitializeComponent();
        _user = user;
        var header = new UserHeader(user);
        MainContainer.Children.Add(header);
        Grid.SetRow(header, 0);

        //foreach (var game in App.Games.Items)
        //    Container.Children.Add(new BetStatisticsGameCard(game, user));
    }

    private void ToNavigationWindow(object sender, RoutedEventArgs e)
    {
        new NavigationWindow(_user).Show();
        Close();
    }
}