using System;
using System.Windows;

namespace DuszaWpfApp;

public partial class AddNewGameWindow : Window
{
    public AddNewGameWindow()
    {
        InitializeComponent();
    }

    private void CreateNewGame(object sender, RoutedEventArgs e)
    {
        try
        {
            
        }   
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}