using System.Linq;
using System.Windows.Controls;
using DuszaTKVGameLib;

namespace DuszaWpfApp.UserControls;

public partial class GameStatisticsCard : UserControl
{
    public GameStatisticsCard(Game game)
    {
        InitializeComponent();
        //var pointsWon = 0;
        //foreach (var bet in App.Bets.BetsByGames[game.Name])
        //{
        //    foreach (var result in game.Events)
        //    {
        //        if (bet.Event == result.Name && bet.Subject == result.Subject && bet.Result == result.Result)
        //            pointsWon += (int)(result.Odds(App.Bets) * bet.Stake);
        //    }
        //}
        //Name.Text = game.Name;
        //NumberOfBets.Text = $"Number of bets placed: {App.Bets.BetsByGames[game.Name].Count}";
        //OverallStakes.Text = $"Overall points placed: {App.Bets.BetsByGames[game.Name].Sum(x => x.Stake)}";
        //OverallPointsWon.Text = $"Overall points won: {(game.IsInProgress ? 0 : pointsWon)}";
    }
}