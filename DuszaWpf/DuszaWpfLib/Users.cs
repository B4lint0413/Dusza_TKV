using DuszaTKVGameLib;
using System.Collections.Generic;
using System.Collections.Immutable;
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
    
    public List<string> ToFile => AllUsers.Select(x=>x.ToString()).ToList();

    public User UserLogIn(string username, string passwd)
    {
        if (AllUsers.Find(x => x.Name == username && x.Password == passwd) == null)
        {
            throw new InvalidUserNameOrPasswdException();
        }
		return AllUsers.Find(x => x.Name == username && x.Password == passwd)!;
    }

    public User? this[string index]
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

    public void DistributePoints(Game game)
    {
        foreach (var user in AllUsers)
        {
            var bet = user.PlacedBets.AllBets.Find(x => x.GameToBet == game.Name);
            if (bet is not null)
                user.Points += bet.Stake * 2;
        }
    }

    public Bets BetsOfApp {
        get
        {
            var bets = new Bets();
            foreach (var user in AllUsers)
            {
                foreach (var bet in user.PlacedBets.AllBets)
                {
                    bets.AllBets.Add(bet);
                }
            }
            return bets;
        }
    }
}