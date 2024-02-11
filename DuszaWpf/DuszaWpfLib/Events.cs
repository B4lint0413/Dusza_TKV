using System.Collections.Generic;
using System.Linq;

namespace DuszaTKVGameLib;

public class Events
{
    public Events(IEnumerable<Event> events)
    {
        _eventList = events.ToList();
    }
    public static Events operator +(Events events, IEnumerable<Event> e)
    {
        var eventList = events._eventList.Select(x => x).ToList();
        eventList.AddRange(e);
        return new Events(eventList);
    }
    private readonly List<Event> _eventList;
    public Event? this[int id] => _eventList.Find(x => x.Id == id); 
    public IEnumerable<Event> this[string gameName] => _eventList.Where(x => x.GameName == gameName);
}