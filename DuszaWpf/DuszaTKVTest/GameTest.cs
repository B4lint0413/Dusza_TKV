using System.Windows.Documents;
using DuszaTKVGameLib;

namespace DuszaTKVTest;

[TestClass]
public class GameTest
{
    [TestMethod]
    public void GameToStringReturns()
    {
        var subjects = new List<User>();
        var events = new List<string>();
        subjects.Add(new User("hululu", "asdasd"));
        var organizer = new User("organizer", "asdasd");
        events.Add("eat");
        events.Add("sleep");
        events.Add("repeat");
        var game = new Game("game", ref organizer, subjects, events);
        Assert.AreEqual("organizer;game;1;3\nhululu\neat\nsleep\nrepeat", game.ToString());
    }
}