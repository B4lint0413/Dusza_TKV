using System;

namespace DuszaTKVGameLib.Exceptions;

public class NonUniqueGameNameException : Exception
{
    public NonUniqueGameNameException()
        :base ("A game with same name already exists!")
        {
            
        }
}