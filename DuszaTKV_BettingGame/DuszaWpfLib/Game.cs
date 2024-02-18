using System.Collections.Generic;
using System.Linq;

namespace DuszaTKVGameLib
{
    public class Game
    {
        public Game(string name, string organizer, IEnumerable<Event> events)
        {
            Name = name;
            Organizer = organizer;
            _events = events.ToList();
        }
        public string Name { get; init; }
        public string Organizer { get; init; }
        private readonly List<Event> _events;
        public bool IsInProgress => string.Join("", _events.Select(x => x.Result)) == "";
        public string ResultsToString() => $"{Name}\n{string.Join("\n", _events)}";
        public override string ToString() => $"{Organizer};{Name};{_events.DistinctBy(x => x.Subject).Count()};{_events.DistinctBy(x => x.Name).Count()}\n{string.Join("\n", _events.Select(x => x.Subject).Distinct())}\n{string.Join("\n", _events.Select(x => x.Name).Distinct())}";
        public void EndGame(IEnumerable<string> results)
        {
            var resultsList = results.ToList();
            for (var i = 0; i < resultsList.Count; i++)
                _events[i].Result = resultsList[i];
        }
        public IEnumerable<string> Subjects => _events.Select(x => x.Subject).Distinct();
        public IEnumerable<Event> Events => _events;
    }
}
