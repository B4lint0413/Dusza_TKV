using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace DuszaTKVGameLib
{
    public class Bet
    {
        public Bet(string player, string gameToBet, string result, string subject, string _event, int stake)
        {
            if (result == "")
                throw new EmptyFieldException();
            if (result.Length > LengthLimitExceededException.LENGTH_LIMIT)
                throw new LengthLimitExceededException();

            if (stake<=0)
            {
                throw new NonPositiveStakeException();
            }

            Player = player;
            GameToBet = gameToBet;
            Subject = subject;
            Event = _event;
            Result = result;
            Stake = stake;
        }

        public string Player { get; init; }
        public string GameToBet { get; init; }
        public string Subject { get; init; }
        public string Event { get; init; }
        public string Result { get; init; }
        public int Stake { get; init; }

        public override string ToString()
        {
            return $"{Player};{GameToBet};{Result};{Subject};{Event};{Stake}";
        }
    }
}
