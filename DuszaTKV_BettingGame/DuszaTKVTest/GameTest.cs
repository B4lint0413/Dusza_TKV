using System.Windows.Documents;
using DuszaTKVGameLib;
using DuszaTKVGameLib.Exceptions;

namespace DuszaTKVTest;

[TestClass]
public class GameTest
{
    [TestMethod]
    public void GameToStringTest()
    {
        var events = new List<Event>();
        events.Add(new Event("asdasd",  "hululu", "game"));
        var game = new Game("game", "organizer", events);
        Assert.AreEqual("organizer;game;1;1\nhululu\nasdasd", game.ToString());
    }

    [TestMethod]
    public void ResultsToStringTest()
    {
        var events = new List<Event>();
        events.Add(new Event("asdasd", "hululu", "game"));
        var game = new Game("game", "organizer", events);
        Assert.AreEqual("game\nhululu;asdasd;;0", game.ResultsToString());
    }

    [TestMethod]
    public void GamesToStringTest()
    {
        var events = new List<Event>();
        events.Add(new Event("asdasd", "hululu", "game"));
        var gameList = new List<Game>();
        gameList.Add(new Game("game", "organizer", events));
        gameList.Add(new Game("game2", "organizer", events));
        var games = new Games(gameList);
        Assert.AreEqual("organizer;game;1;1\nhululu\nasdasd\norganizer;game2;1;1\nhululu\nasdasd", games.ToString());
        var game = new Game("game3", "organizer", events);
        var temp = games + game;
        Assert.AreEqual("organizer;game;1;1\nhululu\nasdasd\norganizer;game2;1;1\nhululu\nasdasd", games.ToString());
        Assert.AreEqual("organizer;game;1;1\nhululu\nasdasd\norganizer;game2;1;1\nhululu\nasdasd\norganizer;game3;1;1\nhululu\nasdasd", temp.ToString());
    }

    [TestMethod]
    public void EndGameTest()
    {
        var events = new List<Event>();
        events.Add(new Event("asdasd", "hululu", "game"));
        var game = new Game("game", "organizer", events);
        Assert.AreEqual("", game.Events.ElementAt(0).Result);
        var result = new List<string>() { "result" };
        Assert.IsTrue(game.IsInProgress);
        game.EndGame(result);
        Assert.AreEqual("result", game.Events.ElementAt(0).Result);
        Assert.IsFalse(game.IsInProgress);
        Assert.AreEqual("game\nhululu;asdasd;result;0", game.ResultsToString());
    }

    [TestMethod]
    public void CreatingGameWithNonUniqueNameThrowsException()
    {
        var events = new List<Event>
        {
            new Event("asdasd", "hululu", "game")
        };
        var gameList = new List<Game>
        {
            new Game("game", "organizer", events),
            new Game("game2", "organizer", events)
        };
        var games = new Games(gameList);
        var game = new Game("game", "organizer", events);
        Assert.ThrowsException<NonUniqueGameNameException>(() => games += game);
    }
}