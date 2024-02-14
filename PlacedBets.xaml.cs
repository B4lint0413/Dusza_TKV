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
using System.Windows.Shapes;

namespace DuszaWpfApp
{
    /// <summary>
    /// Interaction logic for PlacedBets.xaml
    /// </summary>
    public partial class PlacedBets : Window
    {
        public PlacedBets(User player)
        {
            InitializeComponent();

            foreach (var bet in App.Bets.AllBets.Where(x=>x.Player == player.Name))
            {
                Container.Children.Add(new PlacedBet(bet));
            }

        }
    }
}
