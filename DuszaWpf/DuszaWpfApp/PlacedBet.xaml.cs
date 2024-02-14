using DuszaTKVGameLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DuszaWpfApp
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
