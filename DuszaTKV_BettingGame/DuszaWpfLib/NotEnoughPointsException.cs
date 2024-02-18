using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuszaTKVGameLib
{
    public class NotEnoughPointsException : Exception
    {
        public NotEnoughPointsException() : base("You don't have enough points!") { }
    }
}
