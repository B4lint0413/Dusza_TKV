using System.Collections.Generic;
using System.Linq;

namespace DuszaTKVGameLib;

public class Users
{
    public List<User> AllUsers = new List<User>();

    public List<string> Names => AllUsers.Select(x=>x.Name).ToList();
    
    public List<string> ToFile => AllUsers.Select(x=>x.ToFile).ToList();
}