﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuszaTKVGameLib
{
    public class User
    {
        public User(string name, string password)
        {
            Name = name;
            Password = password;
            Points = 100;
        }

        public User(string name, string password, int points)
        {
            Name = name;
            Password = password;
            Points = points;
        }
        public string Name {get; init; }
        private string Password { get; init; }
        private int _points;

        public int Points
        {
            get
            {
                return _points;
            }
            set
            {
                _points = value;
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

        public string ToFile => $"{Name};{Password};{Points}";
    }
}
