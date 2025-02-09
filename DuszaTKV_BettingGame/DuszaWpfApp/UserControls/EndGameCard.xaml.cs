using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DuszaTKVGameLib;
using DuszaWpfApp.Windows;

namespace DuszaWpfApp.UserControls;

public partial class EndGameCard : UserControl
{
    public EndGameCard()
    {
        InitializeComponent();
    }

    private void EndGame(object sender, RoutedEventArgs e)
    {
        //new EndGameWindow(_game, _organizer).Show();
        Window.GetWindow(Parent)!.Close();
    }
}