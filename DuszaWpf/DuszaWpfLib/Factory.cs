using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace DuszaTKVGameLib;

public static class Factory
{
    public static void NewUserToUsers(User user, Users users)
    {
        if (users.Names.Contains(user.Name))
        {
            throw new DuplicateUsersException();
        }
        users.AllUsers.Add(user);
    }
    
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
        if ((passwdFromInPut.Length < 8 || !Regex.IsMatch(passwdFromInPut, "(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!,@,#,$,%,^,&,*,?,_,~,-,(,)])")) && checkSecurity)
        {
            throw new NotSecurePasswordException();
        }
		using (SHA256 sha256 = SHA256.Create())
		{
			byte[] hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwdFromInPut));
			return System.Text.Encoding.UTF8.GetString(hashedBytes);
		}
	}

    public static Bet CreateBet(string row)
    {
        string[] splitted = row.Split(";");
        return new Bet(splitted[0], splitted[1], splitted[2], splitted[3], splitted[4], int.Parse(splitted[5]));
    }
}