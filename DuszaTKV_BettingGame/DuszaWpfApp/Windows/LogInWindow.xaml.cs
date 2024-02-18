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
		public void LogIn(object sender, EventArgs e)
		{
			try
			{
				string userName = username.Text;
				string password = Factory.PasswdFactory(passwd.Password, false);
				if (password == "" || userName == "")
					throw new EmptyFieldException();
				if (userName.Length > LengthLimitExceededException.LENGTH_LIMIT)
					throw new LengthLimitExceededException();
				var user = App.Users.UserLogIn(userName, password);
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
