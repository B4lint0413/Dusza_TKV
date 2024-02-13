﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuszaTKVGameLib
{
    public class NotSecurePasswordException : Exception
    {
        public NotSecurePasswordException() : base("Your password needs to:\n\tbe at least 8 characters long;\n\tcontain a special character;\n\t" +
            "contain a lower case letter;\n\tcontain an upper case letter;\n\tcontain a number!"){ }

    }
}
