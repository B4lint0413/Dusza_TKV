using System;

namespace DuszaTKVGameLib.Exceptions;

public class DuplicateBetException : Exception
{
    public DuplicateBetException()
        : base("You have already placed a bet on this event-subject combination!")
    {
        
    }
}