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
using DuszaTKVGameLib;
using DuszaWpfApp.Windows;

namespace DuszaWpfApp
{
	/// <summary>
	/// Interaction logic for LeaderboardWindow.xaml
	/// </summary>
	public partial class LeaderboardWindow : Window
	{
		private readonly User _user;
		public LeaderboardWindow(User user)
		{
			InitializeComponent();
			_user = user;
			foreach (var item in App.Users.Items.OrderBy(x => x.Points))
			{
				string outString = $"{item.Name} : {item.Points}";
				leaderboard.Items.Add(outString);
			}
		}
		private void ToNavigationWindow(object sender, RoutedEventArgs e)
		{
			new NavigationWindow(_user).Show();
			Close();
		}
	}
}
