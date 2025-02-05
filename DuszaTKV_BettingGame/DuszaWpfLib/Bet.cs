using DuszaTKVGameLib.Exceptions;
using DuszaTKVGameLib.Interfaces;

namespace DuszaTKVGameLib
{
    public class Bet : IIdentified
    {
        public Bet(int userId, int gameId, string result, int subjectId, int eventId, int stake)
        {
            if (result == "")
                throw new EmptyFieldException();
            if (result.Length > LengthLimitExceededException.LENGTH_LIMIT)
                throw new LengthLimitExceededException();
            if (stake <= 0)
                throw new NonPositiveStakeException();

            UserId = userId;
            GameId = gameId;
            SubjectId = subjectId;
            EventId = eventId;
            Result = result;
            Stake = stake;
        }

        public int UserId { get; init; }
        public int GameId { get; init; }
        public int SubjectId { get; set; }
        public int EventId { get; init; }
        public string Result { get; set; }
        public int Stake { get; set; }

        public int Id { get; set; }

        public override string ToString()
        {
            return $"{UserId};{GameId};{Result};{SubjectId};{EventId};{Stake}";
        }
    }
}
