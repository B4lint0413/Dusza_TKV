using System.Collections.Generic;
using System.Linq;

namespace DuszaTKVGameLib;

public class Events
{
    public Events(IEnumerable<Event> events)
    {
        _eventList = events.ToList();
    }
    private readonly List<Event> _eventList;
    public IEnumerable<Event> this[string gameName] => _eventList.Where(x => x.GameName == gameName);
}