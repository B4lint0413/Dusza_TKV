using System.Security.Cryptography;
using DuszaTKVGameLib;
using DuszaTKVGameLib.Exceptions;

namespace DuszaTKVTest;

[TestClass]
public class UserTest
{
    [TestMethod]
    public void NewUsersNameIsAccessibleAndPointsByDefaultIs100()
    {
        User usr = new("Gipsz Jakab", "Delulu!0"); 
        Assert.AreEqual("Gipsz Jakab", usr.Name);
        Assert.AreEqual(100, usr.Points);
    }

    [TestMethod]
    public void IndividualUsersCanBeAccessedThroughIndexer()
    {
        var users = new Users(new List<User>()
        {
            new("jack", "Delulu!0"),
            new("john", "Delulu!0")
        });
        Assert.AreEqual(null, users["mary"]);
        Assert.AreEqual("jack", users["jack"]!.Name);
    }

    [TestMethod]
    public void UserToStringReturnsPropertiesSeperatedBySemicolon()
    {
        var user = new User("jack", "Delulu!0");
        Assert.AreEqual($"jack;{System.Text.Encoding.UTF8.GetString(SHA256.HashData(System.Text.Encoding.UTF8.GetBytes("Delulu!0")))};100", user.ToString());
    }

    [TestMethod]
    public void PointsCanBeAssignedFromConstructor()
    {
        var user = new User("jack", "Delulu!0", 32);
        Assert.AreEqual(32, user.Points);
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