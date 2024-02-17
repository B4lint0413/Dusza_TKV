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

namespace DuszaWpfApp
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        private Dictionary<int, UIElement> levels = new Dictionary<int, UIElement>();
        private Brush red = new SolidColorBrush(Colors.Red);
        private Brush green = new SolidColorBrush(Colors.Green);

        public SignUpWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            levels.Add(16, Long);
            levels.Add(8, Special);
            levels.Add(4, Digit);
            levels.Add(2, Upper);
            levels.Add(1, Lower);

        }

        public void NavigateToLogIn(object sender, EventArgs e)
        {
            new LogInWindow().Show();
            Close();
        }

        public void SignUpNewUser(object sender, RoutedEventArgs e)
        {
            string name = username.Text;
            string password = passwd.Password;
            string passwordAgain = passwdAgain.Password;
           
            if (password==passwordAgain)
            {
                try
                {
                    Factory.NewUserToUsers(new User(name,password),App.Users);
                    username.Text = "";
                    passwd.Password = "";
                    passwdAgain.Password = "";
                    MessageBox.Show("You have signed up successfully", "Successful registration", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("The confirmation password differs from the password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void StrengthLevel(object sender, RoutedEventArgs e)
        {
            Lower.Foreground = red;
            Upper.Foreground = red;
            Digit.Foreground = red;
            Special.Foreground = red;
            Long.Foreground = red;
            int strengthLevel = Factory.StrengthCheck(passwd.Password);

            foreach (var level in levels)
            {
                if (strengthLevel>=level.Key)
                {
                    ((TextBlock)level.Value).Foreground = green;
                    strengthLevel -= level.Key;
                }
            }
        }
	}
}
