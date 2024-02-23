using System;

namespace DuszaTKVGameLib.Exceptions
{
    public class NonPositiveStakeException : Exception
    {
        public NonPositiveStakeException() : base("The stake must be greater than zero!") { }
    }
}
