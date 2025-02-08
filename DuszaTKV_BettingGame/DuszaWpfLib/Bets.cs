using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuszaTKVGameLib.Exceptions;

namespace DuszaTKVGameLib
{
    public sealed class Bets : ClassList<Bet>
    {
        public Bets(IEnumerable<Bet> items) : base(items) { }
        public Bets() : base() { }

        public Dictionary<int, List<Bet>> BetsByGames => items.GroupBy(x => x.GameId).ToDictionary(x=>x.Key, x=>x.ToList());

        public override Bet this[string index]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public override ClassList<Bet> AddItem(Bet item)
        {
            if (items.Exists(x =>
                    x.GameId == item.GameId
                    && x.User.Name == item.User.Name
                    && x.Event == item.Event
                    && x.Subject == item.Subject))
                throw new DuplicateBetException();
            var temp = new Bets(items);
            temp.items.Add(item);
            return temp;
        }
    }
}
