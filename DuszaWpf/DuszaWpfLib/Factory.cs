using System.Collections.Generic;

namespace DuszaTKVGameLib;

public static class Factory
{
    public static void NewUserToUsers(User user, Users users)
    {
        if (users.Names.Contains(user.Name))
        {
            throw new DuplicateUsersException();
        }
        users.AllUsers.Add(user);
    }
    
    public static Game CreateGame(string text, Events events)
    {
        var data = text.Split("\n");
        var header = data[0].Split(';');
        var organizer = header[0];
        var name = header[1];
        return new Game(name, organizer, events[name]);
    }

    public static Event CreateEvent(string line, string gameName)
    {
        var data = line.Split(";");
        return new Event(data[1], data[0], gameName, data[2], double.Parse(data[3]));
    }
}