using DuszaTKVGameLib;
using System.Collections.Generic;
using System.Linq;

namespace DuszaTKVGameLib;

public class Users
{
    public List<User> AllUsers = new List<User>();

    public List<string> Names => AllUsers.Select(x=>x.Name).ToList();

    private List<string> Passwords => AllUsers.Select(x => x.Password).ToList();
    
    public List<string> ToFile => AllUsers.Select(x=>x.ToFile).ToList();

    public void UserLogIn(string username, string passwd)
    {
        if (!(Names.Contains(username) && Passwords.Contains(passwd)))
        {
            throw new InvalidUserNameOrPasswdException();
        }
    }
}