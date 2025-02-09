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
using DuszaWpfApp.UserControls;
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
			//WindowStartupLocation = WindowStartupLocation.CenterScreen;
			//var header = new UserHeader(user);
			//MainContainer.Children.Add(header);
			//Grid.SetRow(header, 0);
			//_user = user;
			//var placement = 0;
			//var counter = 0;
			//var points = -1;
			//foreach (var item in App.Users.Items.OrderByDescending(x => x.Points))
			//{
			//	counter++;
			//	if (points != item.Points)
			//		placement = counter;
			//	Container.Children.Add(new LeaderBoardCard(item, placement));
			//	points = item.Points;
			//}
		}
		private void ToNavigationWindow(object sender, RoutedEventArgs e)
		{
			new NavigationWindow(_user).Show();
			Close();
		}
	}
}
