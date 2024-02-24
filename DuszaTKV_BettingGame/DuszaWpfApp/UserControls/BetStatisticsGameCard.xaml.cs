using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DuszaTKVGameLib;
using DuszaWpfApp.Windows;

namespace DuszaWpfApp.UserControls;

public partial class BetStatisticsGameCard : UserControl
{
    private readonly Game _game;
    private readonly User _user;
    public BetStatisticsGameCard(Game game, User user)
    {
        InitializeComponent();
        _game = game;
        _user = user;
        Header.Text = game.Name;
        var extraHeight = (game.Subjects.Count() + game.Events.DistinctBy(x => x.Name).Count()) * 15;
        Card.Height += extraHeight;
        Container.Height += extraHeight;
        Grid.Height += extraHeight;
        Text.Height += extraHeight;

        Body.Text += "Subjects:";
        foreach (var subject in game.Subjects)
            Body.Text+=$"\n\t{subject}";

        Body.Text += "\nEvents:";
        foreach (var eventName in game.Events.Select(x => x.Name).Distinct())
            Body.Text += $"\n\t{eventName}";
    }

    private void CheckBetStatistics(object sender, RoutedEventArgs e)
    {
        new BetStatisticsWindow(_user, _game).Show();
        Window.GetWindow(Parent)!.Close();
    }
}