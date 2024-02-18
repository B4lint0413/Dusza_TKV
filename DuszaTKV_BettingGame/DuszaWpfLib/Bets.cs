using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessibility;
using DuszaTKVGameLib.Exceptions;

namespace DuszaTKVGameLib
{
    public sealed class Bets : ClassList<Bet>
    {
        public Bets(IEnumerable<Bet> items) : base(items) { }
        public Bets() : base() { }

        public Dictionary<string, List<Bet>> BetsByGames => items.GroupBy(x => x.GameToBet).ToDictionary(x=>x.Key, x=>x.ToList());

        public override Bet this[string index]
        {
            get
            {
               throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        protected override ClassList<Bet> AddItem(Bet item)
        {
            if (items.Exists(x =>
                    x.GameToBet == item.GameToBet
                    && x.Player == item.Player
                    && x.Event == item.Event
                    && x.Subject == item.Subject))
                throw new DuplicateBetException();
            items.Add(item);
            return this;
        }
    }
}
