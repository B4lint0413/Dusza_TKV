using DuszaTKVGameLib.Exceptions;
using DuszaTKVGameLib.Interfaces;

namespace DuszaTKVGameLib
{
    public class Bet : IIdentified
    {
        public Bet(string player, string gameToBet, string result, string subject, string @event, int stake)
        {
            if (result == "")
                throw new EmptyFieldException();
            if (result.Length > LengthLimitExceededException.LENGTH_LIMIT)
                throw new LengthLimitExceededException();
            if (stake <= 0)
                throw new NonPositiveStakeException();

            Player = player;
            GameToBet = gameToBet;
            Subject = subject;
            Event = @event;
            Result = result;
            Stake = stake;
        }

        public string Player { get; init; }
        public string GameToBet { get; init; }
        public string Subject { get; init; }
        public string Event { get; init; }
        public string Result { get; init; }
        public int Stake { get; init; }

        public int Id { get; set; }

        public override string ToString()
        {
            return $"{Player};{GameToBet};{Result};{Subject};{Event};{Stake}";
        }
    }
}
