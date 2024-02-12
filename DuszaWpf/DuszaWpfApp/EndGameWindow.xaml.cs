using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DuszaTKVGameLib;

namespace DuszaWpfApp;

public partial class EndGameWindow : Window
{
    private readonly Game _game;
    private readonly User _organizer;
    public EndGameWindow(Game game, User organizer)
    {
        InitializeComponent();
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
                if (result.Result.Text == "")
                    throw new EmptyFieldException();
                results.Add(result.Result.Text);
            }
            _game.EndGame(results);
            File.WriteAllText("Files/jatekok.txt", App.Games.ToString());
            File.WriteAllText("Files/eredmenyek.txt", App.Games.ResultsToString());
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