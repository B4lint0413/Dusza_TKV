using DuszaTKVGameLib;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using DuszaTKVGameLib.Exceptions;

namespace DuszaTKVGameLib;

public class Users
{
    private readonly List<User> _allUsers;

    public Users()
    {
        _allUsers = new List<User>();
    }
    public Users(IEnumerable<User> users)
    {
        _allUsers = users.ToList();
    }

    private List<string> Names => _allUsers.Select(x=>x.Name).ToList();

    public override string ToString() => string.Join("\n", _allUsers);

    public User UserLogIn(string username, string passwd)
    {
        var user = _allUsers.Find(x => x.Name == username && x.Password.HashedPassword == passwd);
        if (user == null)
            throw new InvalidUserNameOrPasswdException();
		return user;
    }

    public static Users operator +(Users users, User user)
    {
        if (users.Names.Contains(user.Name))
            throw new DuplicateUsersException();
        var temp = new Users();
        foreach (var u in users._allUsers)
            temp._allUsers.Add(u);
        temp._allUsers.Add(user);
        return temp;
    }
    public User? this[string index]
    {
        get
        {
            return _allUsers.Find(x => x.Name == index);
        }

        set
        {
            _allUsers[_allUsers.FindIndex(x => x.Name == index)] = value;
        }
    }

    public void DistributePoints(Game game)
    {
        foreach (var user in _allUsers)
        {
            foreach (var bet in user.PlacedBets.AllBets.Where(x => x.GameToBet == game.Name))
            {
                foreach (var result in game.Events)
                {
                    if (bet.Event == result.Name && bet.Subject == result.Subject && bet.Result == result.Result)
                        user.Points += bet.Stake * 2;
                }
            }
        }
    }
}