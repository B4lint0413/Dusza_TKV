namespace DuszaTKVGameLib;

public class Event
{
    public Event(string name, User subject)
    {
        Name = name;
        Result = "";
        Subject = subject;
        Odds = 0;
    }
    public string Name { get; init; }
    public User Subject { get; init; }
    public string Result { get; set; }
    public double Odds { get; }
    public override string ToString()
    {
        return $"{Subject.Name};{Name};{Result};{Odds}";
    }
}