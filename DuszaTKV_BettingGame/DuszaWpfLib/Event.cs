using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using DuszaTKVGameLib.Exceptions;
using DuszaTKVGameLib.Interfaces;

namespace DuszaTKVGameLib;

public class Event : IIdentified
{
    public Event(string name, string subject, int gameId, string result = "")
    {
        if (name == "" || subject == "")
            throw new EmptyFieldException();
        if (name.Length > LengthLimitExceededException.LENGTH_LIMIT ||
            subject.Length > LengthLimitExceededException.LENGTH_LIMIT)
            throw new LengthLimitExceededException();
        Name = name;
        Result = result;
        Subject = subject;
        GameId = gameId;
    }
    public int GameId { get; init; }
    public Game? Game { get; set; }
    public string Name { get; init; }
    public string Subject { get; init; }
    public string Result { get; set; }

    public int Id { get; set; }

    public List<Bet> Bets { get; set; } 

    public double Odds(Bets bets)
    {
        var numberOfBets = bets.Items
            .Count(x => x.Event.Name == Name && x.GameId == GameId && x.Subject == Subject);
        return numberOfBets == 0 ? 0 : Math.Round(1 + 5.0 / Math.Pow(2, numberOfBets - 1), 2);
    }
    public override string ToString()
    {
        return $"{Subject};{Name};{Result};{Odds}";
    }
}