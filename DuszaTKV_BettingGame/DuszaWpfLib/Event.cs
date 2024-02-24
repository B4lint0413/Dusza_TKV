using System;
using System.Linq;
using DuszaTKVGameLib.Exceptions;

namespace DuszaTKVGameLib;

public class Event
{
    public Event(string name, string subject, string gameName, string result = "")
    {
        if (name == "" || subject == "")
            throw new EmptyFieldException();
        if (name.Length > LengthLimitExceededException.LENGTH_LIMIT ||
            subject.Length > LengthLimitExceededException.LENGTH_LIMIT)
            throw new LengthLimitExceededException();
        Name = name;
        Result = result;
        Subject = subject;
        GameName = gameName;
    }
    public string GameName { get; init; }
    public string Name { get; init; }
    public string Subject { get; init; }
    public string Result { get; set; }
    public double Odds(Bets bets)
    {
        var numberOfBets = bets.Items
            .Count(x => x.Event == Name && x.GameToBet == GameName && x.Subject == Subject);
        return numberOfBets == 0 ? 0 : Math.Round(1 + 5.0 / Math.Pow(2, numberOfBets - 1), 2);
    }
    public override string ToString()
    {
        return $"{Subject};{Name};{Result};{Odds}";
    }
}