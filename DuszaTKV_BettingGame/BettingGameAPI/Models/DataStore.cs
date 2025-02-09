using DuszaTKVGameLib;

namespace BettingGameAPI.Models
{
    public class DataStore : IDataStore
    {
        public DataStore(DatabaseContext context)
        {
            Bets = new Repository<Bet>(context.Bets);
            Events = new Repository<Event>(context.Events);
            Users = new Repository<User>(context.Users);
            Games = new Repository<Game>(context.Games);
        }

        public Repository<Bet> Bets { get; } 
        public Repository<Event> Events { get; }
        public Repository<User> Users { get; }
        public Repository<Game> Games { get; }

    }
}
