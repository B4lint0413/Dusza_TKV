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
			Assert.AreEqual(hash, HashedPasswdFactory.PasswdFactory("asd123"));
			Assert.AreEqual(HashedPasswdFactory.PasswdFactory("password"), HashedPasswdFactory.PasswdFactory("password"));
		}
	}
}