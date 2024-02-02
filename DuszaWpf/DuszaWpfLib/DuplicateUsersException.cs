using System;

namespace DuszaWpfLib;

public class DuplicateUsersException : Exception
{
    public DuplicateUsersException() : base("User is already existing!"){}
}