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
        private Game currentGame;
        private User player;
        public BetCard(User user, Game game)
        {
            InitializeComponent();

            int Height = (game.Subjects.Count() + game.Events.DistinctBy(x => x.Name).Count()) * 15;
            
            Card.Height += Height;
            Border.Height += Height;
            Grid.Height += Height;
            Content.Height += Height;

            Header.Text = game.Name;
            
            currentGame = game;
            player = user;

            Body.Text += "Subjects:";
            foreach (string subject in game.Subjects)
            {
                Body.Text+=$"\n\t{subject}";
            }

            Body.Text += "\nEvents:";
            foreach (string _event in game.Events.Select(x => x.Name).Distinct())
            {
                Body.Text += $"\n\t{_event}";
            }
        }

        private void MakeBetWindow(object sender, RoutedEventArgs e)
        {
            new MakeBetWindow(player, currentGame).Show();
            Window.GetWindow(Parent)!.Close();
        }
    }
}
