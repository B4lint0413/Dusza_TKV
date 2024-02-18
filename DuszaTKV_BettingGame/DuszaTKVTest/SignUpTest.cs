using DuszaTKVGameLib;

namespace DuszaTKVTest;

[TestClass]
public class SignUpTest
{
    [TestMethod]
    public void NewUsersNameIsAccessibleAndPointsByDefaultIs100()
    {
        User usr = new("Gipsz Jakab", "jelszó"); 
        Assert.AreEqual("Gipsz Jakab", usr.Name);
        Assert.AreEqual(100, usr.Points);
    }

    [TestMethod]
    public void ForExistingUser50PointsCanBeDefinedInConstructor()
    {
        User usr = new("Gipsz Jakab", "jelszó", 50);
        Assert.AreEqual(50, usr.Points);
    }

    [TestMethod]
    public void TryingToCreateAnExistingUserThrowsError()
    {
        Users users = new();
        Factory.NewUserToUsers(new User("Gipsz Jakab", "jelszó"),users);
        Assert.ThrowsException<DuplicateUsersException>(() => Factory.NewUserToUsers(new User("Gipsz Jakab", "jelszó"),users));
    }
}