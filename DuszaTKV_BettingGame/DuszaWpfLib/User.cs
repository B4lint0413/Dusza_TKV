using DuszaTKVGameLib.Exceptions;
using DuszaTKVGameLib.Interfaces;

namespace DuszaTKVGameLib
{
    public class User : IIdentified
    {
        private Bets _placedBets;
        public User(string name, string password) // New user
        {
            if (name == "")
                throw new EmptyFieldException();
            if (name.Length > LengthLimitExceededException.LENGTH_LIMIT)
                throw new LengthLimitExceededException();
            Name = name;
            Password = new Password(password);
            Password.CheckSecurity();
            Points = 100;
            _placedBets = new Bets();
        }

        public User(string name, string password, int points) // Existing user
        {
            Name = name;
            Password = new Password(password, true);
            Points = points;
            _placedBets = new Bets();
        }
        public string Name {get; init; }
        public Password Password { get; init; }
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
        public Bet MakeBet(string gameToBet, string result, string subject, string @event, int stake)
        {
            var bet = new Bet(Name, gameToBet, result, subject, @event, stake);
            Points -= stake;
            _placedBets = (Bets)_placedBets.AddItem(bet);
            return bet;
        }
    }
}
