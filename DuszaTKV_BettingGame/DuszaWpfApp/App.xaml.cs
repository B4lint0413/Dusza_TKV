using DuszaTKVGameLib;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace DuszaWpfApp
{
    public partial class App : Application
    {
        public static Users Users = new(GenerateUsers("Files/users.txt"));
        public static Events Events = new(GenerateEvents("Files/eredmenyek.txt"));
        public static Games Games = new(GenerateGames("Files/jatekok.txt", Events));
        public static Bets Bets = new(GenerateBets(Users, "Files/fogadasok.txt"));
        private static string _currentGameName;
        public App()
        {
            
        }
        private static IEnumerable<User> GenerateUsers(string filename)
        {
            foreach (var line in File.ReadAllLines(filename))
                yield return Factory.CreateUser(line);
        }
        private static IEnumerable<Bet> GenerateBets(Users users, string filename)
        {
            foreach (var row in File.ReadAllLines(filename))
                yield return Factory.CreateBet(users, row);
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
		public static void UpdateOdds()
		{
			foreach (var item in Bets.Items.OrderBy(x => x.Stake))
			{
				if (item.Stake > 900)
				{
					Event _event = Events.GetEvents.First(x => x.Name == item.Event);
					_event.Odds = _event.Odds * 0.95;
					Events = Events + _event;
				}
				else
				{
					Event _event = Events.GetEvents.First(x => x.Name == item.Event);
					_event.Odds = _event.Odds * 1.5;
					Events = Events + _event;
				}
			}
		}

		private void AppExit(object sender, ExitEventArgs e)
        {
            File.WriteAllText("Files/users.txt", Users.ToString());
            File.WriteAllText("Files/fogadasok.txt", Bets.ToString());
            File.WriteAllText("Files/jatekok.txt", App.Games.ToString());
            File.WriteAllText("Files/eredmenyek.txt", App.Games.ResultsToString());
            
        }
    }
}
