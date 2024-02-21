using DuszaTKVGameLib;
using DuszaTKVGameLib.Exceptions;

namespace DuszaTKVTest
{
	[TestClass]
	public class PasswordTest
	{
		[TestMethod]
		public void EmptyPasswordThrowsException()
		{
			Assert.ThrowsException<EmptyFieldException>(() => new Password(""));
		}

		[TestMethod]
		public void TooLongPasswordThrowsException()
		{
			Assert.ThrowsException<LengthLimitExceededException>(() =>
				new Password("asdfasdfasdfdsafdsafdsafdsafdfrrredsafdsasafdsa"));
		}
		
		[TestMethod]
		public void IfPasswordIsEmptyStrengthCheckReturns0()
		{
			Assert.AreEqual(0, Password.GetSecurityLevel(""));
		}

		[TestMethod]
		public void IfPasswordContainsALowercaseLetterReturns1()
		{
            Assert.AreEqual(1, Password.GetSecurityLevel("a"));
        }

        [TestMethod]
        public void IfPasswordContainsAnUppercaseLetterReturns2()
        {
            Assert.AreEqual(2, Password.GetSecurityLevel("A"));
        }

        [TestMethod]
        public void IfPasswordContainsADigitReturns4()
        {
            Assert.AreEqual(4, Password.GetSecurityLevel("0"));
        }

        [TestMethod]
        public void IfPasswordContainsASpecialCharReturns8()
        {
            Assert.AreEqual(8, Password.GetSecurityLevel("@"));
        }

        [TestMethod]
        public void IfPasswordLengthIs8OrGreaterOfLowercaseLettersReturns17()
        {
            Assert.AreEqual(17, Password.GetSecurityLevel("aaaaaaaaaaaa"));
        }

        [TestMethod]
        public void IfPasswordContainsEverythingButShortReturns15()
        {
            Assert.AreEqual(15, Password.GetSecurityLevel("aA1?"));
        }

        [TestMethod]
        public void IfPasswordSecureEnoughReturns31()
        {
            Assert.AreEqual(31, Password.GetSecurityLevel("QDs2?aWop12@"));
        }

        [TestMethod]
        public void PasswdFactoryThrowsErrorIfPasswdIsNotSecureEnough()
        {
	        var passwd = new Password("asd1?");
            Assert.ThrowsException<NotSecurePasswordException>(()=>passwd.CheckSecurity());
        }
    }
}