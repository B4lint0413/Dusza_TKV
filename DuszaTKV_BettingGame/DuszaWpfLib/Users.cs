using System.Collections.Generic;
using System.Linq;
using DuszaTKVGameLib.Exceptions;

namespace DuszaTKVGameLib;

public sealed class Users : ClassList<User>
{
    public Users(IEnumerable<User> items) : base(items) { }
    public Users() : base() { }

    private List<string> Names => items.Select(x=>x.Name).ToList();

    public User UserLogIn(string username, string passwd)
    {
        if (passwd == "" || username == "")
            throw new EmptyFieldException();
        if (username.Length > LengthLimitExceededException.LENGTH_LIMIT)
            throw new LengthLimitExceededException();
        var user = items.Find(x => x.Name == username && x.Password.HashedPassword == passwd);
        if (user == null)
            throw new InvalidUserNameOrPasswdException();
		return user;
    }

    
    public override User? this[string index]
    {
        get => items.Find(x => x.Name == index);
        set => items[items.FindIndex(x => x.Name == index)] = value;
    }

    public void DistributePoints(Game game, Bets allBets)
    {
        foreach (var user in items)
        {
            List<Bet> bets;
            if(user.PlacedBets.BetsByGames.TryGetValue(game.Name, out bets))
            {
                foreach (var bet in bets)
                {
                    foreach (var result in game.Events)
                    {
                        if (bet.Event == result.Name && bet.Subject == result.Subject && bet.Result == result.Result)
                            user.Points += (int)(result.Odds(allBets) * bet.Stake);
                    }
                }
            }
        }
    }
    public override ClassList<User> AddItem(User item)
    {
        if (Names.Contains(item.Name))
            throw new DuplicateUsersException();
        items.Add(item);
        return this;
        
    }
}