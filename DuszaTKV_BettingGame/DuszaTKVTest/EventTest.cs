using DuszaTKVGameLib;
using DuszaTKVGameLib.Exceptions;

namespace DuszaTKVTest;

[TestClass]
public class EventTest
{
    [TestMethod]
    public void TooLongEventNameOrSubjectNameThrowsException()
    {
        Assert.ThrowsException<LengthLimitExceededException>(() => new Event("asdfasdfasfdsafdsafasddfasddsf", "asd", "asd"));
        Assert.ThrowsException<LengthLimitExceededException>(() => new Event("asd", "asdasdfasdfasdfsadfdsafdsafasd", "asd"));
    }
    
    [TestMethod]
    public void EmptyEventNameOrSubjectNameThrowsException()
    {
        Assert.ThrowsException<EmptyFieldException>(() => new Event("", "asd", ""));
        Assert.ThrowsException<EmptyFieldException>(() => new Event("asd", "", ""));
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
    public void IndexerReturnsEventsOfCertainGame()
    {
        var events = new Events(new List<Event>()
        {
            new ("delulu", "jack", "hululu"),
            new ("delulu", "john", "hululu"),
            new ("ff", "mary", "game")
        });
        Assert.AreEqual(2, events["hululu"].Count());
        Assert.AreEqual(1, events["game"].Count());
        events += new List<Event>(){ new ( "damn", "mary", "game")};
        Assert.AreEqual(2, events["game"].Count());
    }

    [TestMethod]
    public void TestSubjectsOfGame()
    {
        var game = new Game("hululu", "jack", new List<Event>()
        {
            new("event", "john", "hululu"),
            new("event", "mary", "hululu")
        });
        Assert.AreEqual(2, game.Subjects.Count());
        Assert.AreEqual("john;mary", string.Join(";", game.Subjects));
    }

    [TestMethod]
    public void EventsToString()
    {
        Assert.AreEqual("asd;hululu;;0", new Event("hululu", "asd", "asd").ToString());
    }
}