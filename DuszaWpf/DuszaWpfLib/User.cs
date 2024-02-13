using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace DuszaTKVGameLib
{
    public class User
    {
        public User(string name, string password) // New user
        {
            if (password == "" || name == "")
                throw new EmptyFieldException();
            if (password.Length > LengthLimitExceededException.LENGTH_LIMIT ||
                name.Length > LengthLimitExceededException.LENGTH_LIMIT)
                throw new LengthLimitExceededException();
            Name = name;
            Password = Factory.PasswdFactory(password);
            Points = 100;
        }

        public User(string name, string password, int points) // Existing user
        {
            Name = name;
            Password = password;
            Points = points;
        }
        public string Name {get; init; }
        public string Password { get; init; }
        private int points;
        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                if (value<0)
                {
                    throw new NotEnoughPointsException();
                }
                points = value;
            }
        }

        private bool _isOrganiser = false;
        public bool IsOrganiser
        {
            get
            {
                return _isOrganiser;
            }
            set 
            {
                _isOrganiser = value;
            }
        }

        public override string ToString() => $"{Name};{Password};{Points}";

        public Bet MakeBet(string gameToBet, string result, string subject, string _event, int stake)
        {
            Points -= stake;
            return new Bet(Name, gameToBet, result, subject, _event, stake);
        }
    }
}
