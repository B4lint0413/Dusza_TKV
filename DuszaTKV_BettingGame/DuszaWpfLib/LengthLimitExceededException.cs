using System;

namespace DuszaTKVGameLib;

public class LengthLimitExceededException : Exception
{
    public const int LENGTH_LIMIT = 20;
    public LengthLimitExceededException()
        : base($"The maximum length for an input string is {LENGTH_LIMIT}!")
    {
        
    }
}