using System;

namespace DuszaTKVGameLib;

public class DuplicateUsersException : Exception
{
    public DuplicateUsersException() : base("User already exists!"){}
}