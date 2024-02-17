using DuszaTKVGameLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            UserHeader header = new UserHeader(user);
            MainContainer.Children.Add(header);
            Grid.SetRow(header, 0);

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
                Bet bet = player.MakeBet(currentGame.Name, Result.Text, Subject.SelectedItem.ToString()??"",
                    Event.SelectedItem.ToString()??"", int.TryParse(Stake.Text, out a) ? int.Parse(Stake.Text) : 0);
                App.Users.BetsOfApp.AllBets.Add(bet);
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
