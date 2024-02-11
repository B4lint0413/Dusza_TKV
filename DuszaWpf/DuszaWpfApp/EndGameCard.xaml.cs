using System.Linq;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using DuszaTKVGameLib;

namespace DuszaWpfApp;

public partial class EndGameCard : UserControl
{
    public EndGameCard(Game game)
    {
        InitializeComponent();
        Header.Text = game.Name;
        var plusHeight = (game.Subjects.Count() + game.Events.DistinctBy(x => x.Name).Count()) * 15;
        Card.Height += plusHeight;
        Container.Height += plusHeight;
        Grid.Height += plusHeight;
        Text.Height += plusHeight;

        Body.FontSize = 14;
        Body.Text += "Subjects:";
        foreach (var subject in game.Subjects)
            Body.Text+=$"\n\t{subject}";

        Body.Text += "\nEvents:";
        foreach (var eventName in game.Events.Select(x => x.Name).Distinct())
            Body.Text += $"\n\t{eventName}";
    }

    private void EndGame(object sender, RoutedEventArgs e)
    {
        
    }
}