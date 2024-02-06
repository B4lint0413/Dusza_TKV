using System.Collections.Generic;
using System.Linq;

namespace DuszaTKVGameLib
{
    public class Game
    {
        public Game(string name, User organizer, IEnumerable<Event> events)
        {
            Name = name;
            Organizer = organizer;
            _events = events.ToList();
            IsInProgress = true;
        }
        public string Name { get; init; }
        public User Organizer { get; init; }
        private readonly List<Event> _events;
        public bool IsInProgress { get; private set; }
        public string ResultsToString()
        {
            return $"{Name}\n{string.Join("\n", _events)}";
        }
        public override string ToString()
        {
            return $"{Organizer.Name};{Name};{_events.Count};{_events.Count}\n{string.Join("\n", _events.Select(x => x.Subject.Name).Distinct())}\n{string.Join("\n", _events.Select(x => x.Name).Distinct())}";
        }
        public void EndGame(IEnumerable<string> results)
        {
            IsInProgress = false;
            var resultsList = results.ToList();
            for (var i = 0; i < resultsList.Count; i++)
                _events[i].Result = resultsList[i];
        }
        public IEnumerable<User> Subjects => _events.Select(x => x.Subject).DistinctBy(x => x.Name);
        public IEnumerable<Event> Events => _events;
    }
}
