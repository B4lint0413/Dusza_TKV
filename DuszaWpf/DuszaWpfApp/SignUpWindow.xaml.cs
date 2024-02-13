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
        public SignUpWindow()
        {
            InitializeComponent();
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
                    if (password == "" || name == "")
                        throw new EmptyFieldException();
                    if (password.Length > LengthLimitExceededException.LENGTH_LIMIT ||
                        name.Length > LengthLimitExceededException.LENGTH_LIMIT)
                        throw new LengthLimitExceededException();
                    Factory.NewUserToUsers(new User(name,Factory.PasswdFactory(password)),App.Users);
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
	}
}
