using System.Collections.Generic;
using System.Linq;
using DuszaTKVGameLib.Exceptions;
using DuszaTKVGameLib.Interfaces;

namespace DuszaTKVGameLib
{
    public class Game : IIdentified
    {
        public Game(string name, int organiserId, IEnumerable<Event> events)
        {
            var eventList = events.ToList();
            if (name == "")
                throw new EmptyFieldException();
            if (name.Length > LengthLimitExceededException.LENGTH_LIMIT)
                throw new LengthLimitExceededException();
            Name = name;
            OrganiserId = organiserId;
            _events = eventList.ToList();
        }
        public string Name { get; init; }
        public int OrganiserId { get; init; }
        private readonly List<Event> _events;
        public bool IsInProgress => string.Join("", _events.Select(x => x.Result)) == "";
        public string ResultsToString() => $"{Name}\n{string.Join("\n", _events)}";
        public override string ToString() => $"{Organiser.Name};{Name};{_events.DistinctBy(x => x.Subject).Count()};{_events.DistinctBy(x => x.Name).Count()}\n{string.Join("\n", _events.Select(x => x.Subject).Distinct())}\n{string.Join("\n", _events.Select(x => x.Name).Distinct())}";
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

        public int Id {get; set;}
        public User? Organiser { get; set; }
    }
}
