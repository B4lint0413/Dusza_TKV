using DuszaTKVGameLib;
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
        public static Users Users = new Users();
        public static Bets Bets = new Bets();
        //public static Games Games = new Games();

        public App()
        {
            foreach (string row in File.ReadAllLines("Files/users.txt"))
            {
                string[] splitted = row.Split(";");
                Factory.NewUserToUsers(new User(splitted[0], splitted[1], int.Parse(splitted[2])), Users);
            }
        }

        public void AppExit(object sender, ExitEventArgs e)
        {
            File.WriteAllText("Files/users.txt", string.Join("\n", Users.ToFile));
        }
    }
}
