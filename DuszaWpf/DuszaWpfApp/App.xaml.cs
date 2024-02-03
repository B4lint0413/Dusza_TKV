using DuszaWpfLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DuszaWpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Users users = new Users();
        public static Bets bets = new Bets();
        public static Games games = new Games();

        public App()
        {
            foreach (string row in File.ReadAllLines("Files/users.txt"))
            {
                string[] splitted = row.Split(";");
                UserFactory.NewUserToUsers(new User(splitted[0], splitted[1], int.Parse(splitted[2])), users);
            }
        }

        public void AppExit(object sender, ExitEventArgs e)
        {
            File.WriteAllText("Files/users.txt", string.Join("\n", users.ToFile));
        }
    }
}
