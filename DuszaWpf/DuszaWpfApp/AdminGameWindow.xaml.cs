﻿using System;
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
        private readonly User _organizer;
        public AdminGameWindow(User organizer)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _organizer = organizer;
            foreach (var game in App.Games.GetOwnGames(organizer.Name))
                GameCardContainer.Children.Add(new EndGameCard(game, organizer, this));
        }
        
        private void CreateNewGame(object sender, RoutedEventArgs e)
        {
            new CreateNewGameWindow(_organizer).Show();
            Close();
        }

        private void ToNavigationWindow(object sender, RoutedEventArgs e)
        {
            new NavigationWindow(_organizer).Show();
            Close();
        }
    }
}
