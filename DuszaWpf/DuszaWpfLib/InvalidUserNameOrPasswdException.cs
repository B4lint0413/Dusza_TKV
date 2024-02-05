using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuszaTKVGameLib
{
	public class InvalidUserNameOrPasswdException : Exception
	{
        public InvalidUserNameOrPasswdException() : base("Invalid username or password!")
        {
            
        }
    }
}
