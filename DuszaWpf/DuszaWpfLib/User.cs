﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace DuszaTKVGameLib
{
    public class User
    {
        private readonly List<Bet> _placedBets;
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
            _placedBets = new List<Bet>();
        }

        public User(string name, string password, int points) // Existing user
        {
            Name = name;
            Password = password;
            Points = points;
            _placedBets = new List<Bet>();
        }
        public string Name {get; init; }
        public string Password { get; init; }
        private int _points;
        public int Points
        {
            get
            {
                return _points;
            }
            set
            {
                if (value<0)
                {
                    throw new NotEnoughPointsException();
                }
                _points = value;
            }
        }

        private bool _isOrganiser = false;

        public User(List<Bet> placedBets)
        {
            _placedBets = placedBets;
        }

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
        public IEnumerable<Bet> PlacedBets => _placedBets.Select(x => x); 
        public void AddBet(Bet bet)
        {
            _placedBets.Add(bet);
        }
        public Bet MakeBet(string gameToBet, string result, string subject, string @event, int stake)
        {
            Points -= stake;
            var bet = new Bet(Name, gameToBet, result, subject, @event, stake);
            _placedBets.Add(bet);
            return bet;
        }
    }
}
