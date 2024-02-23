using System.Windows.Controls;
using DuszaTKVGameLib;

namespace DuszaWpfApp.UserControls
{
    /// <summary>
    /// Interaction logic for PlacedBet.xaml
    /// </summary>
    public partial class PlacedBet : UserControl
    {
        public PlacedBet(Bet bet)
        {
            InitializeComponent();

            Header.Text = bet.GameToBet;
            Body.Text += $"Subject: {bet.Subject}";
            Body.Text += $"\nEvent: {bet.Event}";
            Body.Text += $"\nResult: {bet.Result}";
            Body.Text += $"\nStake: {bet.Stake} points";
        }
    }
}
