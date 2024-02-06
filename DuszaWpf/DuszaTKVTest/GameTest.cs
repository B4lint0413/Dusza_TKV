using System.Windows.Documents;
using DuszaTKVGameLib;

namespace DuszaTKVTest;

[TestClass]
public class GameTest
{
    [TestMethod]
    public void GameToStringTest()
    {
        var events = new List<Event>();
        var organizer = new User("organizer", "asdasd");
        events.Add(new Event("asdasd", "asd", new User("hululu", "asdasd")));
        var game = new Game("game", organizer, events);
        Assert.AreEqual("organizer;game;1;1\nhululu\nasdasd", game.ToString());
    }

    [TestMethod]
    public void ResultsToStringTest()
    {
        var events = new List<Event>();
        var organizer = new User("organizer", "asdasd");
        events.Add(new Event("asdasd", "asd", new User("hululu", "asdasd")));
        var game = new Game("game", organizer, events);
        Assert.AreEqual("game\nhululu;asdasd;asd;0", game.ResultsToString());
    }

    [TestMethod]
    public void GamesToStringTest()
    {
        var events = new List<Event>();
        var organizer = new User("organizer", "asdasd");
        events.Add(new Event("asdasd", "asd", new User("hululu", "asdasd")));
        var gameList = new List<Game>();
        gameList.Add(new Game("game", organizer, events));
        gameList.Add(new Game("game2", organizer, events));
        var games = new Games(gameList);
        Assert.AreEqual("organizer;game;1;1\nhululu\nasdasd\norganizer;game2;1;1\nhululu\nasdasd", games.ToString());
    }
}