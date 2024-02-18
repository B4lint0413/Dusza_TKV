using System;
using System.IO;
using System.Linq;
using System.Windows;
using DuszaTKVGameLib;
using DuszaTKVGameLib.Exceptions;

namespace DuszaWpfApp.Windows;

public partial class CreateNewGameWindow : Window
{
    private readonly User _organizer;
    public CreateNewGameWindow(User organizer)
    {
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
        InitializeComponent();
        _organizer = organizer;
    }

    private void CreateNewGame(object sender, RoutedEventArgs e)
    {
        try
        {
            var gameName = GameName.Text;
            var events = Events.Text;
            var subjects = Subjects.Text;
            var eventList = (from ev in events.Split(';') 
                from subject in subjects.Split(';') 
                select new Event(ev, subject, gameName))
                .ToList();
            var game = new Game(gameName, _organizer.Name, eventList);
            App.Games += game;
            App.Events += eventList;
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