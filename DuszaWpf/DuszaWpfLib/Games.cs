using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuszaTKVGameLib
{
    public class Games
    {
        private List<Game> GameList { get; set; }

        public Games(IEnumerable<Game> games)
        {
            GameList = games.ToList();
        }

        public override string ToString()
        {
            return string.Join("\n", GameList);
        }
        public Game? this[string name] => GameList.Find(x => x.Name == name);
    }
}
