using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessibility;
using DuszaTKVGameLib.Exceptions;

namespace DuszaTKVGameLib
{
    public class Bets
    {
        private readonly List<Bet> _allBets;

        public Bets()
        {
            _allBets = new List<Bet>();
        }
        public Bets(IEnumerable<Bet> bets)
        {
            _allBets = bets.ToList();
        }

        public IEnumerable<Bet> AllBets => _allBets.Select(x => x);

        public static Bets operator +(Bets bets, Bet bet)
        {
            if (bets._allBets.Exists(x =>
                    x.GameToBet == bet.GameToBet
                    && x.Player == bet.Player
                    && x.Event == bet.Event
                    && x.Subject == bet.Subject))
                throw new DuplicateBetException();
            var temp = new Bets(bets._allBets);
            temp._allBets.Add(bet);
            return temp;
        }
        public Dictionary<string, List<Bet>> BetsByGames => _allBets.GroupBy(x => x.GameToBet).ToDictionary(x=>x.Key, x=>x.ToList());
        public IEnumerable<string> ToFile => _allBets.Select(x => x.ToString()).ToList();
    }
}
