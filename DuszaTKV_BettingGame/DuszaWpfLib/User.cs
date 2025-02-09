using DuszaTKVGameLib.Exceptions;
using DuszaTKVGameLib.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Windows.Documents;

namespace DuszaTKVGameLib
{
    public class User : IIdentified
    {
        private Bets _placedBets;
        public User(string name, string passwordString) // New user
        {
            if (name == "")
                throw new EmptyFieldException();
            if (name.Length > LengthLimitExceededException.LENGTH_LIMIT)
                throw new LengthLimitExceededException();
            Name = name;
            Password = new Password(passwordString);
            PasswordString = passwordString;
            Password.CheckSecurity();
            Points = 100;
            _placedBets = new Bets();
        }

        [JsonConstructor]
        public User(string name, string passwordString, int points) // Existing user
        {
            Name = name;
            Password = new Password(passwordString, true);
            PasswordString = passwordString;
            Points = points;
            _placedBets = new Bets();
        }
        public string Name {get; set; }
        [JsonIgnore]
        public string PasswordString { get; set; }
        [NotMapped]
        public Password Password { get; set; }
        private int _points;
        public int Points
        {
            get => _points;
            set
            {
                if (value<0)
                    throw new NotEnoughPointsException();
                _points = value;
            }
        }
        public override string ToString() => $"{Name};{Password.HashedPassword};{Points}";
        public Bets PlacedBets => new Bets(_placedBets.Items);

        public int Id { get; set; }

        public void AddBet(Bet bet)
        {
            _placedBets = (Bets)_placedBets.AddItem(bet);
        }

        public List<Bet> Bets { get; set; }
        public List<Game> Games { get; set; }

        public Bet MakeBet(int gameToBet, string result, string subject, int @event, int stake)
        {
            var bet = new Bet(Id, gameToBet, result, subject, @event, stake);
            Points -= stake;
            _placedBets = (Bets)_placedBets.AddItem(bet);
            return bet;
        }
    }
}
