using System;

namespace DuszaTKVGameLib.Exceptions
{
    public class NotEnoughPointsException : Exception
    {
        public NotEnoughPointsException() : base("You don't have enough points!") { }
    }
}
