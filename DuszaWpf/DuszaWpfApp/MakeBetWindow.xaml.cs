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
    /// Interaction logic for MakeBetWindow.xaml
    /// </summary>
    public partial class MakeBetWindow : Window
    {
        private Game currentGame;
        private User player;
        public MakeBetWindow(User user, Game game)
        {
            InitializeComponent();
            
            currentGame = game;
            player = user;

            Header.Text = game.Name;
            foreach (string subject in game.Subjects)
            {
                Subject.Items.Add(subject);
            }

            foreach (string _event in game.Events.Select(x=>x.Name).Distinct())
            {
                Event.Items.Add(_event);
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            new BetWindow(player).Show();
            Close();
        }

        private void MakeNewBet(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Result.Text == "" || Stake.Text == "")
                    throw new EmptyFieldException();
                if (Result.Text.Length > LengthLimitExceededException.LENGTH_LIMIT ||
                    Stake.Text.Length > LengthLimitExceededException.LENGTH_LIMIT)
                    throw new LengthLimitExceededException();
                Bet bet = player.MakeBet(currentGame.Name, Result.Text, Subject.SelectedItem.ToString() ?? "",
                    Event.SelectedItem.ToString()??"", int.Parse(Stake.Text));
                App.Bets.AllBets.Add(bet);
                App.Users[player.Name] = player;
                Cancel(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
