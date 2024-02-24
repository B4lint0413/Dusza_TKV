using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DuszaTKVGameLib;
using DuszaTKVGameLib.Exceptions;
using DuszaWpfApp.UserControls;

namespace DuszaWpfApp.Windows;

public partial class CreateNewGameWindow : Window
{
    private readonly User _organizer;
    public CreateNewGameWindow(User organizer)
    {
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
        InitializeComponent();
        var header = new UserHeader(organizer);
        MainContainer.Children.Add(header);
        Grid.SetRow(header, 0);
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
            App.Games = (Games)App.Games.AddItem(game);
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