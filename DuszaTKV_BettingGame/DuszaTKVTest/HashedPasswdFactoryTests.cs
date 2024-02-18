using Microsoft.VisualStudio.TestTools.UnitTesting;
using DuszaTKVGameLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Runtime.Intrinsics.Arm;

namespace DuszaTKVGameLib.Tests
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
				byte[] hashedBytes = sHA256.ComputeHash(System.Text.Encoding.UTF8.GetBytes("asd123"));
				hash = hashedBytes.ToString()!;
			}
			Assert.AreEqual(hash, Factory.PasswdFactory("asd123"));
			Assert.AreEqual(Factory.PasswdFactory("password"), Factory.PasswdFactory("password"));
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