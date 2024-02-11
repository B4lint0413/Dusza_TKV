using DuszaTKVGameLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DuszaWpfApp
{
	/// <summary>
	/// Interaction logic for LogInWindow.xaml
	/// </summary>
	public partial class LogInWindow : Window
	{
		public LogInWindow()
		{
			InitializeComponent();
		}
		public void LogIn(object sender, EventArgs e)
		{
			string userName = username.Text;
			string password = Factory.PasswdFactory(passwd.Text);

			try
			{
				var user = App.Users.UserLogIn(userName, password);
				App.ActiveUser = user;
				//new AdminGameWindow(user).Show();
				new BetWindow().Show();
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
