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
    public void EventsToString()
    {
        Assert.AreEqual("asd;hululu;;0", new Event("hululu", "asd", "asd").ToString());
    }
}