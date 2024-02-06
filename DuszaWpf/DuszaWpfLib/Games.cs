using System.Collections.Generic;
using System.Linq;

namespace DuszaTKVGameLib
{
    public class Games
    {
        private readonly List<Game> _gameList;

        public Games(IEnumerable<Game> games)
        {
            _gameList = games.ToList();
        }

        public override string ToString()
        {
            return string.Join("\n", _gameList);
        }
        public Game? this[string name] => _gameList.Find(x => x.Name == name);
    }
}
