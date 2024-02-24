using System.Linq;
using System.Windows.Controls;
using DuszaTKVGameLib;

namespace DuszaWpfApp.UserControls;

public partial class BetStatisticsCard : UserControl
{
    public BetStatisticsCard(Event e)
    {
        InitializeComponent();
        Name.Text = $"{e.Name} - {e.Subject}";
        var pointsWon = 0;
        foreach (var bet in App.Bets.BetsByGames[e.GameName])
        {
            foreach (var result in App.Games[e.GameName]!.Events.Where(x => x.Name == e.Name && x.Subject == e.Subject))
            {
                if (bet.Event == result.Name && bet.Subject == result.Subject && bet.Result == result.Result)
                    pointsWon += (int)(result.Odds(App.Bets) * bet.Stake);
            }
        }
        NumberOfBets.Text = $"Number of bets placed: {
            App.Bets.BetsByGames[e.GameName]
                .Count(x => x.Subject == e.Subject && x.Event == e.Name)}";
        OverallStakes.Text = $"Overall points placed: {
            App.Bets.BetsByGames[e.GameName]
                .Where(x => x.Subject == e.Subject && x.Event == e.Name).Sum(x => x.Stake)}";
        OverallPointsWon.Text = $"Overall points won: {(App.Games[e.GameName]!.IsInProgress ? 0 : pointsWon)}";
    }
}