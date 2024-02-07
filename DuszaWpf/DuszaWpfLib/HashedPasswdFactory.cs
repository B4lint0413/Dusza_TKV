using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DuszaTKVGameLib
{
	public class HashedPasswdFactory
	{
		public static string PasswdFactory(string passwdFromInPut)
		{
			using (SHA256 sha256 = SHA256.Create())
			{
				byte[] hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwdFromInPut));
				return hashedBytes.ToString()!;
			}
		}
	}
}
