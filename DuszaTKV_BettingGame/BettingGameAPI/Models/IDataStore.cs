using DuszaTKVGameLib;

namespace BettingGameAPI.Models
{
    public interface IDataStore
    {
        Repository<Bet> Bets { get; }
        Repository<Event> Events { get; }
        Repository<User> Users { get; }
        Repository<Game> Games { get; }
    }
}
