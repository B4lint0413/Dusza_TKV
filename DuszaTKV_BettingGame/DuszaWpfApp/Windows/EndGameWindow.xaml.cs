using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DuszaTKVGameLib;
using DuszaTKVGameLib.Exceptions;
using DuszaWpfApp.UserControls;

namespace DuszaWpfApp.Windows;

public partial class EndGameWindow : Window
{
    private readonly Game _game;
    private readonly User _organizer;
    public EndGameWindow(Game game, User organizer)
    {
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
        InitializeComponent();
        
        var header = new UserHeader(organizer);
        MainContainer.Children.Add(header);
        Grid.SetRow(header, 0);

        _organizer = organizer;
        _game = game;
        Title.Text += $" {game.Name}";
        foreach (var e in game.Events)
            Container.Children.Add(new EventResultField(e));
    }

    private void CommitResults(object sender, RoutedEventArgs e)
    {
        try
        {
            var results = new List<string>();
            foreach(var item in Container.Children)
            {
                var result = (EventResultField)item;
                results.Add(result.Result.Text);
            }
            _game.EndGame(results);
            App.Users.DistributePoints(_game, App.Bets);
            new AdminGameWindow(_organizer).Show();
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void ToNavigationWindow(object sender, RoutedEventArgs e)
    {
        new NavigationWindow(_organizer).Show();
        Close();
    }
}