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

        public static Games operator +(Games games, Game game)
        {
            var gameList = games._gameList.Select(x => x).ToList();
            gameList.Add(game);
            return new Games(gameList);
        }

        public IEnumerable<Game> GetOwnGames(string name) => _gameList.Where(x => x.Organizer == name && x.IsInProgress);
        public IEnumerable<Game> GetBettableGames(string name) => _gameList.Where(x => x.Organizer != name && x.IsInProgress);
        public Game? this[string name] => _gameList.Find(x => x.Name == name);
    }
}
