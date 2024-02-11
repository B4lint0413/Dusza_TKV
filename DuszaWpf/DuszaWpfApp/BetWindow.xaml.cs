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
    /// Interaction logic for BetWindow.xaml
    /// </summary>
    public partial class BetWindow : Window
    {
        public BetWindow(User user)
        {
            InitializeComponent();
            foreach (Game game in App.Games.GetBettableGames(user.Name))
            {
                BetCardContainer.Children.Add(new BetCard(user, game));
            }
        }
    }
}
