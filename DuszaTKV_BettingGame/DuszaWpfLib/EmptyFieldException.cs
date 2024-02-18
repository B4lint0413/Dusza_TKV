using System;

namespace DuszaTKVGameLib;

public class EmptyFieldException : Exception
{
    public EmptyFieldException()
        : base("A required field has been left empty!")
    {

    }
}