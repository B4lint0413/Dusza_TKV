using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DuszaTKVGameLib;
using DuszaWpfApp.UserControls;

namespace DuszaWpfApp.Windows
{
    public partial class MakeBetWindow : Window
    {
        private readonly Game currentGame;
        private readonly User player;
        public MakeBetWindow(User user, Game game)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            UserHeader header = new UserHeader(user);
            MainContainer.Children.Add(header);
            Grid.SetRow(header, 0);

            currentGame = game;
            player = user;

            Header.Text = game.Name;
            foreach (var subject in game.Subjects)
            {
                Subject.Items.Add(subject);
            }

            foreach (var _event in game.Events.Select(x=>x.Name).Distinct())
            {
                Event.Items.Add(_event);
            }

            Subject.SelectedIndex = 0;
            Event.SelectedIndex = 0;
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
                int a;
                var bet = player.MakeBet(currentGame.Name, Result.Text, Subject.SelectedItem.ToString()??"",
                    Event.SelectedItem.ToString()??"", int.TryParse(Stake.Text, out a) ? int.Parse(Stake.Text) : 0);
                App.Bets += bet;
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
