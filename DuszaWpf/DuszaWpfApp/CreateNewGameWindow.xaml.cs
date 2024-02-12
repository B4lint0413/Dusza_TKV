using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using DuszaTKVGameLib;

namespace DuszaWpfApp;

public partial class CreateNewGameWindow : Window
{
    private readonly User _organizer;
    public CreateNewGameWindow(User organizer)
    {
        InitializeComponent();
        _organizer = organizer;
    }

    private void CreateNewGame(object sender, RoutedEventArgs e)
    {
        try
        {
            var gameName = GameName.Text;
            if (App.Games[gameName] != null)
                throw new NonUniqueGameNameException();
            var events = Events.Text;
            var subjects = Subjects.Text;
            if (gameName == "" || events == "" || subjects == "")
                throw new EmptyFieldException();
            var eventList = (from ev in events.Split(';') 
                from subject in subjects.Split(';') 
                select new Event(ev, subject, gameName))
                .ToList();
            App.Events += eventList;
            var game = new Game(gameName, _organizer.Name, App.Events[gameName]);
            App.Games += game;
            File.WriteAllText("Files/jatekok.txt", App.Games.ToString());
            File.WriteAllText("Files/eredmenyek.txt", App.Games.ResultsToString());
            new AdminGameWindow(_organizer).Show();
            Close();
        }   
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void ToNavigationWindow(object sender, RoutedEventArgs e)
    {
        new NavigationWindow(_organizer).Show();
        Close();
    }
}