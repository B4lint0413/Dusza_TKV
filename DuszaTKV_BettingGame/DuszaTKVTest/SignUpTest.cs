using DuszaTKVGameLib;
using DuszaTKVGameLib.Exceptions;

namespace DuszaTKVTest;

[TestClass]
public class SignUpTest
{
    [TestMethod]
    public void NewUsersNameIsAccessibleAndPointsByDefaultIs100()
    {
        User usr = new("Gipsz Jakab", "Delulu!0"); 
        Assert.AreEqual("Gipsz Jakab", usr.Name);
        Assert.AreEqual(100, usr.Points);
    }

    [TestMethod]
    public void TryingToCreateAnExistingUserThrowsError()
    {
        Users users = new();
        users = (Users)users.AddItem(new User("Gipsz Jakab", "Delulu!0"));
        Assert.ThrowsException<DuplicateUsersException>(() => users.AddItem(new User("Gipsz Jakab", "Delulu!0")));
    }

    [TestMethod]
    public void TryingToLoginToANonExistentUserThrowsException()
    {
        var users = new Users();
        Assert.ThrowsException<InvalidUserNameOrPasswdException>(() => users.UserLogIn("hululu", "delulu"));
    }
}