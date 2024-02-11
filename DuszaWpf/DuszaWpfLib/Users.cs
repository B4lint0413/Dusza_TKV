using DuszaTKVGameLib;
using System.Collections.Generic;
using System.Linq;

namespace DuszaTKVGameLib;

public class Users
{
    public List<User> AllUsers;

    public Users()
    {
        AllUsers = new List<User>();
    }

    public Users(IEnumerable<User> users)
    {
        AllUsers = users.ToList();
    }

    public List<string> Names => AllUsers.Select(x=>x.Name).ToList();

    private List<string> Passwords => AllUsers.Select(x => x.Password).ToList();
    
    public List<string> ToFile => AllUsers.Select(x=>x.ToString()).ToList();

    public User UserLogIn(string username, string passwd)
    {
        if (!(Names.Contains(username) && Passwords.Contains(passwd)))
        {
            throw new InvalidUserNameOrPasswdException();
        }
		return AllUsers.Find(x => x.Name == username && x.Password == passwd)!;
    }

    public User this[string index]
    {
        get
        {
            return AllUsers.Find(x => x.Name == index);
        }

        set
        {
            AllUsers[AllUsers.FindIndex(x => x.Name == index)] = value;
        }
    }
}