namespace DuszaTKVGameLib;

public static class UserFactory
{
    public static void NewUserToUsers(User user, Users users)
    {
        if (users.Names.Contains(user.Name))
        {
            throw new DuplicateUsersException();
        }
        users.AllUsers.Add(user);
    }
}