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
        public static Users users = new Users();
        public static Bets bets = new Bets();
        //public static Games Games = new Games();

        public App()
        {
            foreach (string row in File.ReadAllLines("Files/users.txt"))
            {
                string[] splitted = row.Split(";");
                Factory.NewUserToUsers(new User(splitted[0], splitted[1], int.Parse(splitted[2])), users);
            }

            foreach (string row in File.ReadAllLines("Files/fogadasok.txt"))
            {
                bets.AllBets.Add(Factory.CreateBet(row));
            }
        }

        public void AppExit(object sender, ExitEventArgs e)
        {
            File.WriteAllText("Files/users.txt", string.Join("\n", users.ToFile));
            File.WriteAllText("Files/fogadasok.txt", string.Join("\n", bets.ToFile));

        }
    }
}
