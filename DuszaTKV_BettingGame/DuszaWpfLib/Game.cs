using System.Collections.Generic;
using System.Linq;
using DuszaTKVGameLib.Exceptions;

namespace DuszaTKVGameLib
{
    public class Game
    {
        public Game(string name, string organizer, IEnumerable<Event> events)
        {
            var eventList = events.ToList();
            if (name == "" || 
                string.Join("", eventList.Select(x => x.Name)) == "" || 
                string.Join("", eventList.Select(x => x.Subject)) == "")
                throw new EmptyFieldException();
            if (name.Length > LengthLimitExceededException.LENGTH_LIMIT ||
                eventList.Any(x => x.Name.Length > LengthLimitExceededException.LENGTH_LIMIT || 
                eventList.Any(y => y.Subject.Length > LengthLimitExceededException.LENGTH_LIMIT)))
                throw new LengthLimitExceededException();
            Name = name;
            Organizer = organizer;
            _events = eventList.ToList();
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
            {
                if (resultsList[i] == "")
                    throw new EmptyFieldException();
                if (resultsList[i].Length > LengthLimitExceededException.LENGTH_LIMIT)
                    throw new LengthLimitExceededException();
                _events[i].Result = resultsList[i];
            }
        }
        public IEnumerable<string> Subjects => _events.Select(x => x.Subject).Distinct();
        public IEnumerable<Event> Events => _events;
    }
}
