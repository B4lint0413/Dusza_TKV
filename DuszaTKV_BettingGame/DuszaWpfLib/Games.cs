﻿using System;
using System.Collections.Generic;
using System.Linq;
using DuszaTKVGameLib.Exceptions;

namespace DuszaTKVGameLib
{
    public sealed class Games : ClassList<Game>
    {
        public string ResultsToString()
        {
            return string.Join("\n", items.Select(x => x.ResultsToString()));
        }

        public Games(IEnumerable<Game> items) : base(items) { }
        public Games() : base() { }

        public IEnumerable<Game> GetOwnGames(string name) => items.Where(x => x.Organizer == name && x.IsInProgress);
        public IEnumerable<Game> GetBettableGames(string name) => items.Where(x => x.Organizer != name && x.IsInProgress);

        protected override ClassList<Game> AddItem(Game item)
        {
            if (this[item.Name] != null)
                throw new NonUniqueGameNameException();
            items.Add(item);
            return this;
        }

        public override Game? this[string name]
        {
            get
            {
                return items.Find(x => x.Name == name);
            }

            set
            {
                items[items.FindIndex(x => x.Name == name)] = value;
            }
        }
    }
}
