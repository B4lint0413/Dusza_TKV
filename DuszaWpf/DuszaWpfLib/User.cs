using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuszaWpfLib
{
    public abstract class User
    {
        protected User(string name, string password)
        {
            Name = name;
            Password = password;
        }
        public string Name {get; init; }

        private string Password { get; init; }
    }
}
