using System;
using System.Windows;
using DuszaTKVGameLib;
using DuszaTKVGameLib.Exceptions;

namespace DuszaWpfApp.Windows
{
	/// <summary>
	/// Interaction logic for LogInWindow.xaml
	/// </summary>
	public partial class LogInWindow : Window
	{
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
				if (password == "" || userName == "")
					throw new EmptyFieldException();
				if (userName.Length > LengthLimitExceededException.LENGTH_LIMIT)
					throw new LengthLimitExceededException();
				var user = App.Users.UserLogIn(userName, new Password(password).HashedPassword);
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
