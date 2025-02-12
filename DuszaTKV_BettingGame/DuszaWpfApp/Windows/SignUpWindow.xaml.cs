﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DuszaTKVGameLib;
using DuszaTKVGameLib.APIHandlers;
using DuszaTKVGameLib.DTOs.UserDTOs;

namespace DuszaWpfApp.Windows
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        private Dictionary<int, UIElement> levels = new Dictionary<int, UIElement>();
        private Brush red = new SolidColorBrush(Colors.Red);
        private Brush green = new SolidColorBrush(Colors.Green);
        private readonly UserAPIHandler handler = new UserAPIHandler();

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

        private void NavigateToLogIn(object sender, EventArgs e)
        {
            new LogInWindow().Show();
            Close();
        }

        private void SignUpNewUser(object sender, RoutedEventArgs e)
        {
            var name = username.Text;
            var password = passwd.Password;
            var passwordAgain = passwdAgain.Password;
           
            if (password == passwordAgain)
            {
                try
                {
                    handler.CreateUser(new CreateUserDto() { Name = name, Password = password });
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

        private void StrengthLevel(object sender, RoutedEventArgs e)
        {
            Lower.Foreground = red;
            Upper.Foreground = red;
            Digit.Foreground = red;
            Special.Foreground = red;
            Long.Foreground = red;
            var strengthLevel = Password.GetSecurityLevel(passwd.Password);

            foreach (var level in levels)
            {
                if (strengthLevel >= level.Key)
                {
                    ((TextBlock)level.Value).Foreground = green;
                    strengthLevel -= level.Key;
                }
            }
        }
	}
}
