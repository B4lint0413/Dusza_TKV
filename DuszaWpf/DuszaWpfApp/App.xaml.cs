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
        public static Users Users = new();
        public static Bets Bets = new();
        public static Events Events = new(GenerateEvents("Files/eredmenyek.txt"));
        public static Games Games = new(GenerateGames("Files/jatekok.txt", Events));
        public static User ActiveUser;
        private static string _currentGameName;
        public App()
        {
            foreach (string row in File.ReadAllLines("Files/users.txt"))
            {
                string[] splitted = row.Split(";");
                Factory.NewUserToUsers(new User(splitted[0], splitted[1], int.Parse(splitted[2])), Users);
            }

            foreach (string row in File.ReadAllLines("Files/fogadasok.txt"))
            {
                Bets.AllBets.Add(Factory.CreateBet(row));
            }
        }

        private static IEnumerable<Event> GenerateEvents(string filename)
        {
            foreach (var line in File.ReadAllLines(filename))
            {
                if (line.Contains(';'))
                    yield return Factory.CreateEvent(line, _currentGameName);
                else _currentGameName = line;
            }
        }
        private static IEnumerable<Game> GenerateGames(string filename, Events events)
        {
            foreach (var line in File.ReadAllLines(filename))
            {
                if (line.Contains(';'))
                    yield return Factory.CreateGame(line, events);
            }
        }
        public void AppExit(object sender, ExitEventArgs e)
        {
            int index = Users.AllUsers.FindIndex(x => x.Name == ActiveUser.Name);
            Users.AllUsers[index] = ActiveUser;

            File.WriteAllText("Files/users.txt", string.Join("\n", Users.ToFile));
            File.WriteAllText("Files/fogadasok.txt", string.Join("\n", Bets.ToFile));
        }
    }
}
