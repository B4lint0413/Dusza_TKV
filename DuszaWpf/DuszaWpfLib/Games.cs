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
        public string ResultsToString()
        {
            return string.Join("\n", _gameList.Select(x => x.ResultsToString()));
        }
        public override string ToString()
        {
            return string.Join("\n", _gameList);
        }

        public IEnumerable<Game> GetOwnGames(string name) => _gameList.Where(x => x.Organizer == name);
        public IEnumerable<Game> GetBettableGames(string name) => _gameList.Where(x => x.Organizer != name);
        public Game? this[string name] => _gameList.Find(x => x.Name == name);
    }
}
