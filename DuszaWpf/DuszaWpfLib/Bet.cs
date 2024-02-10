using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuszaTKVGameLib
{
    public class Bet
    {
        public Bet(ref User player, Game gameToBet, string subject, string _event, string result, int stake)
        {
            if (stake<=0)
            {
                throw new NonPositiveStakeException();
            }
            player.Points -= stake;
            Player = player;
            GameToBet = gameToBet;
            Subject = subject;
            Event = _event;
            Result = result;
            Stake = stake;
        }

        public User Player { get; init; }
        public Game GameToBet { get; init; }
        public string Subject { get; init; }
        public string Event { get; init; }
        public string Result { get; init; }
        public int Stake { get; init; }

        public override string ToString()
        {
            return $"{Player.Name};{GameToBet.Name};{Result};{Subject};{Event};{Stake}";
        }
    }
}
