using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuszaTKVGameLib
{
    public class Game
    {
        public Game(string name, ref User organizer, IEnumerable<User> subjects, IEnumerable<string> events)
        {
            Name = name;
            Organizer = organizer;
            _subjects = subjects.ToList();
            Events = new Dictionary<string, string>();
            foreach (var item in events)
                Events.Add(item, "");
            IsInProgress = true;
        }
        public string Name { get; init; }
        public User Organizer { get; init; }
        private readonly List<User> _subjects;
        private Dictionary<string, string> Events { get; set; }
        public bool IsInProgress { get; private set; }

        public override string ToString()
        {
            return $"{Organizer};{Name};{_subjects.Count};{Events.Count}\n{string.Join("\n", _subjects.Select(x => x.Name))}\n{string.Join("\n", Events.Keys)}\n";
        }

        public void EndGame(IEnumerable<string> results)
        {
            IsInProgress = false;
            var temp = new Dictionary<string, string>();
            for(var i = 0; i < results.Count(); ++i)
                temp.Add(Events.Keys.ElementAt(i), results.ElementAt(i));
            Events = temp;
        }
        public IEnumerable<User> Subjects => _subjects;
        public IEnumerable<string> EventNames => Events.Keys;
    }
}
