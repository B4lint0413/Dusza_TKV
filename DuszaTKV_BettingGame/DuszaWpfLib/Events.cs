using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DuszaTKVGameLib;

public class Events
{
    private readonly List<Event> _eventList;
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
	public static Events operator +(Events events,Event e)
	{
		var eventList = events._eventList.Select(x => x).ToList();
        if (eventList.Contains(e))
        {
            eventList.Remove(e);
        }
		eventList.Add(e);
		return new Events(eventList);
	}

	public IEnumerable<Event> GetEvents => _eventList;
	public IEnumerable<Event> this[string gameName] => _eventList.Where(x => x.Game.Name == gameName);
}