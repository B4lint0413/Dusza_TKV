using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuszaTKVGameLib
{
    public class NonPositiveStakeException : Exception
    {
        public NonPositiveStakeException() : base("The stake must be greater than zero!") { }
    }
}
