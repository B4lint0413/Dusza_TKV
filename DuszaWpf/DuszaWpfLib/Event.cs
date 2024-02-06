namespace DuszaTKVGameLib;

public class Event
{
    public Event(string name, string result, User subject)
    {
        Name = name;
        Result = result;
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