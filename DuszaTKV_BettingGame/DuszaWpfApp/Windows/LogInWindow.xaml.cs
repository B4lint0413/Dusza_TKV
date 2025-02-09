using System;
using System.Windows;
using DuszaTKVGameLib;
using DuszaTKVGameLib.APIHandlers;
using DuszaTKVGameLib.DTOs.UserDTOs;
using DuszaTKVGameLib.Exceptions;

namespace DuszaWpfApp.Windows
{
	/// <summary>
	/// Interaction logic for LogInWindow.xaml
	/// </summary>
	public partial class LogInWindow : Window
	{
		private readonly UserAPIHandler handler = new UserAPIHandler();
        public LogInWindow()
		{
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
			InitializeComponent();
		}

		private void LogIn(object sender, EventArgs e)
		{
			try
			{
				var userName = username.Text;
				var password = passwd.Password;
				LoginUserDto login = handler.Login(new CreateUserDto() { Name = userName, Password = password});
				var user = handler.GetUser(login.Id, login.Token);
				new NavigationWindow(user).Show();
				Close();
			}
			catch (Exception ex)
			{
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
		}

		private void NavigateToSignUp(object sender, RoutedEventArgs e)
		{
			new SignUpWindow().Show();
			Close();
		}
	}
}
