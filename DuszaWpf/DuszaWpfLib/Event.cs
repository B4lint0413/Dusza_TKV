namespace DuszaTKVGameLib;

public class Event
{
    private static int _id;
    public Event(string name, string subject, string gameName, string result = "", double odds = 0)
    {
        Name = name;
        Result = result;
        Subject = subject;
        Odds = odds;
        GameName = gameName;
        Id = _id++;
    }
    public int Id { get; init; }
    public string GameName { get; init; }
    public string Name { get; init; }
    public string Subject { get; init; }
    public string Result { get; set; }
    public double Odds { get; set; }
    public override string ToString()
    {
        return $"{Subject};{Name};{Result};{Odds}";
    }
}