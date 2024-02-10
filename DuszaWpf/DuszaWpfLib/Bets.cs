using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuszaTKVGameLib
{
    public class Bets
    {
        public List<Bet> AllBets;

        public Bets()
        {
            AllBets = new List<Bet>();
        }
        public Bets(IEnumerable<Bet> bets)
        {
            AllBets = bets.ToList();
        }

        public Dictionary<string, List<Bet>> BetsByGames => AllBets.GroupBy(x => x.GameToBet).ToDictionary(x=>x.Key, x=>x.ToList());

        public List<string> ToFile => AllBets.Select(x => x.ToString()).ToList();
    }
}
