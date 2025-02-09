using DuszaTKVGameLib.Exceptions;
using DuszaTKVGameLib.Interfaces;

namespace DuszaTKVGameLib
{
    public class Bet : IIdentified
    {
        public Bet(int userId, int gameId, string result, string subject, int eventId, int stake)
        {
            UserId = userId;
            GameId = gameId;
            Subject = subject;
            EventId = eventId;
            Result = result;
            Stake = stake;
        }

        public int UserId { get; init; }
        public User? User { get; set; }
        public int GameId { get; init; }
        public Game? Game { get; set; }
        public string Subject { get; set; }
        public int EventId { get; init; }
        public Event? Event { get; set; }
        public string Result { get; set; }
        public int Stake { get; set; }

        public int Id { get; set; }

        public override string ToString()
        {
            return $"{UserId};{GameId};{Result};{Subject};{EventId};{Stake}";
        }
    }
}
