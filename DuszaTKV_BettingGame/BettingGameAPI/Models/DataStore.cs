using DuszaTKVGameLib;

namespace BettingGameAPI.Models
{
    public class DataStore : IDataStore
    {
        public DataStore()
        {
            Bets = new Repository<Bet>();
            Events = new Repository<Event>();
            Users = new Repository<User>();
            Games = new Repository<Game>();
        }

        public Repository<Bet> Bets { get; } 
        public Repository<Event> Events { get; }
        public Repository<User> Users { get; }
        public Repository<Game> Games { get; }

    }
}
