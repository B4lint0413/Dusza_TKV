using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuszaTKVGameLib
{
    public class Game
    {
        public Game(string name, User organizer, IEnumerable<Event> events)
        {
            Name = name;
            Organizer = organizer;
            Events = events.ToList();
            IsInProgress = true;
        }
        public string Name { get; init; }
        public User Organizer { get; init; }
        private List<Event> Events { get; set; }
        public bool IsInProgress { get; private set; }
        public string ResultsToString()
        {
            return $"{Name}\n{string.Join("\n", Events)}";
        }
        public override string ToString()
        {
            return $"{Organizer.Name};{Name};{Events.Count};{Events.Count}\n{string.Join("\n", Events.Select(x => x.Subject.Name).Distinct())}\n{string.Join("\n", Events.Select(x => x.Name).Distinct())}";
        }

        public void EndGame(IEnumerable<string> results)
        {
            IsInProgress = false;
            for (var i = 0; i < results.Count(); i++)
                Events[i].Result = results.ElementAt(i);
        }
        public IEnumerable<User> Subjects => Events.Select(x => x.Subject).DistinctBy(x => x.Name);
    }
}
