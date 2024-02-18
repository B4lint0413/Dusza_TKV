using System.Security.Cryptography;
using System.Text.RegularExpressions;
using DuszaTKVGameLib.Exceptions;

namespace DuszaTKVGameLib;

public static class Factory
{
    public static Game CreateGame(string line, Events events)
    {
        var header = line.Split(';');
        var organizer = header[0];
        var name = header[1];
        return new Game(name, organizer, events[name]);
    }

    public static Event CreateEvent(string line, string gameName)
    {
        var data = line.Split(";");
        return new Event(data[1], data[0], gameName, data[2], double.Parse(data[3]));
    }

	public static string PasswdFactory(string passwdFromInPut, bool checkSecurity = true)
	{
        if (StrengthCheck(passwdFromInPut)!=31 && checkSecurity)
        {
            throw new NotSecurePasswordException();
        }
		using (SHA256 sha256 = SHA256.Create())
		{
			byte[] hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwdFromInPut));
			return System.Text.Encoding.UTF8.GetString(hashedBytes);
		}
	}

    public static Bet CreateBet(Users users, string row)
    {
        var data = row.Split(";");
        var bet = new Bet(data[0], data[1], data[2], data[3], data[4], int.Parse(data[5]));
        users[bet.Player]!.AddBet(bet);
        return bet;
    }

    public static int StrengthCheck(string password)
    {
        var security = 0;

        if (Regex.IsMatch(password, "(?=.*[a-z])"))
        {
            security += 1;
        }
        if (Regex.IsMatch(password, "(?=.*[A-Z])"))
        {
            security += 2;
        }
        if (Regex.IsMatch(password, "(?=.*[0-9])"))
        {
            security += 4;
        }
        if (Regex.IsMatch(password, "(?=.*[!,@,#,$,%,^,&,*,?,_,~,-,(,)])"))
        {
            security += 8;
        }
        if (password.Length>=8)
        {
            security += 16;
        }

        return security;
    }
    public static User CreateUser(string line)
    {
        var data = line.Split(';');
        return new User(data[0], data[1], int.Parse(data[2]));
    }
}