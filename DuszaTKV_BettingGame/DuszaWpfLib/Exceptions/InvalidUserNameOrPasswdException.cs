using System;

namespace DuszaTKVGameLib.Exceptions
{
	public class InvalidUserNameOrPasswdException : Exception
	{
        public InvalidUserNameOrPasswdException() : base("Invalid username or password!")
        {
            
        }
    }
}
