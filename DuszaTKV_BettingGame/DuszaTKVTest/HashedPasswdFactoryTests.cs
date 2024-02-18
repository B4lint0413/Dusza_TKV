using System.Security.Cryptography;
using DuszaTKVGameLib;
using DuszaTKVGameLib.Exceptions;

namespace DuszaTKVTest
{
	[TestClass]
	public class HashedPasswdFactoryTests
	{
		[TestMethod]
		public void PasswdFactoryTest()
		{
			string hash;
			using (SHA256 sHA256 = SHA256.Create())
			{
				byte[] hashedBytes = sHA256.ComputeHash(System.Text.Encoding.UTF8.GetBytes("Delulu!0"));
				hash = System.Text.Encoding.UTF8.GetString(hashedBytes);
			}
			Assert.AreEqual(hash, Factory.PasswdFactory("Delulu!0"));
			Assert.AreEqual(Factory.PasswdFactory("Delulu!0"), Factory.PasswdFactory("Delulu!0"));
		}

		[TestMethod]
		public void EmptyPasswordThrowsException()
		{
			Assert.ThrowsException<EmptyFieldException>(() => new User("hululu", ""));
		}

		[TestMethod]
		public void TooLongPasswordThrowsException()
		{
			Assert.ThrowsException<LengthLimitExceededException>(() =>
				new User("hululu", "asdfasdfasdfdsafdsafdsafdsafdsafdsa"));
		}
		
		[TestMethod]
		public void IfPasswordIsEmptyStrengthCheckReturns0()
		{
			Assert.AreEqual(0, Factory.StrengthCheck(""));
		}

		[TestMethod]
		public void IfPasswordContainsALowercaseLetterReturns1()
		{
            Assert.AreEqual(1, Factory.StrengthCheck("a"));
        }

        [TestMethod]
        public void IfPasswordContainsAnUppercaseLetterReturns2()
        {
            Assert.AreEqual(2, Factory.StrengthCheck("A"));
        }

        [TestMethod]
        public void IfPasswordContainsADigitReturns4()
        {
            Assert.AreEqual(4, Factory.StrengthCheck("0"));
        }

        [TestMethod]
        public void IfPasswordContainsASpecialCharReturns8()
        {
            Assert.AreEqual(8, Factory.StrengthCheck("@"));
        }

        [TestMethod]
        public void IfPasswordLengthIs8OrGreaterOfLowercaseLettersReturns17()
        {
            Assert.AreEqual(17, Factory.StrengthCheck("aaaaaaaaaaaa"));
        }

        [TestMethod]
        public void IfPasswordContainsEverythingButShortReturns15()
        {
            Assert.AreEqual(15, Factory.StrengthCheck("aA1?"));
        }

        [TestMethod]
        public void IfPasswordSecureEnoughReturns31()
        {
            Assert.AreEqual(31, Factory.StrengthCheck("QDs2?aWop12@"));
        }

        [TestMethod]
        public void PasswdFactoryThrowsErrorIfPasswdIsNotSecureEnough()
        {
            Assert.ThrowsException<NotSecurePasswordException>(()=>Factory.PasswdFactory("aSd1?"));
        }
    }
}