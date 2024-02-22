using System;

namespace DuszaTKVGameLib.Exceptions;

public class LengthLimitExceededException : Exception
{
    public const int LENGTH_LIMIT = 40;
    public LengthLimitExceededException()
        : base($"The maximum length for an input string is {LENGTH_LIMIT}!")
    {
        
    }
}