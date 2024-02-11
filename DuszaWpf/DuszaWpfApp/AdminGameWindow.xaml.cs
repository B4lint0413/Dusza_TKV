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
using DuszaTKVGameLib;

namespace DuszaWpfApp
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class AdminGameWindow : Window
    {
        public AdminGameWindow()
        {
            InitializeComponent();
            foreach (var game in App.Games.GetOwnGames("Pintyő István"))
                GameCardContainer.Children.Add(new EndGameCard(game));
        }
        
        private void CreateNewGame(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
