namespace DuszaTKVGameLib;

public class Event
{
    public Event(string name, string subject, string gameName, string result = "", double odds = 0)
    {
        Name = name;
        Result = result;
        Subject = subject;
        Odds = odds;
        GameName = gameName;
    }
    public string GameName { get; init; }
    public string Name { get; init; }
    public string Subject { get; init; }
    public string Result { get; set; }
    public double Odds { get; }
    public override string ToString()
    {
        return $"{Subject};{Name};{Result};{Odds}";
    }
}