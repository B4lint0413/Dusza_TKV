using System;

namespace DuszaTKVGameLib;

public class NonUniqueGameNameException : Exception
{
    public NonUniqueGameNameException()
        :base ("A game with same name already exists!")
        {
            
        }
}