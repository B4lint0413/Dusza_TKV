using System;

namespace DuszaTKVGameLib.Exceptions;

public class DuplicateUsersException : Exception
{
    public DuplicateUsersException() : base("User already exists!"){}
}