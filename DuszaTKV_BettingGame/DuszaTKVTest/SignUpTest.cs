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
        users += new User("Gipsz Jakab", "Delulu!0");
        Assert.ThrowsException<DuplicateUsersException>(() => users += new User("Gipsz Jakab", "Delulu!0"));
    }
}