using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DuszaTKVGameLib;
using DuszaWpfApp.Windows;

namespace DuszaWpfApp.UserControls
{
    /// <summary>
    /// Interaction logic for BetCard.xaml
    /// </summary>
    public partial class BetCard : UserControl
    {
        public BetCard()
        {
            InitializeComponent();
        }

        private void MakeBetWindow(object sender, RoutedEventArgs e)
        {
            //new MakeBetWindow(player, currentGame).Show();
            Window.GetWindow(Parent)!.Close();
        }
    }
}
