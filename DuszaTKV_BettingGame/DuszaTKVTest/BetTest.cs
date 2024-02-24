using DuszaTKVGameLib;
using DuszaTKVGameLib.Exceptions;

namespace DuszaTKVTest
{
    [TestClass]
    public class BetTest
    {
        [TestMethod]
        public void InitWithConstructorAndReturnsProperToString()
        {
            User player = new User("Gipsz Jakab", "Delulu!0");
            Bet bet = player.MakeBet("Játék", "10", "Béla", "Pontjainak száma", 5);
            Assert.AreEqual("Gipsz Jakab;Játék;10;Béla;Pontjainak száma;5", bet.ToString());
        }

        [TestMethod]
        public void EmptyResultStringThrowsException()
        {
            Assert.ThrowsException<EmptyFieldException>(() => new Bet("asd", "asd", "", "asd", "asd", 5));
        }

        [TestMethod]
        public void TooLongResultStringThrowsException()
        {
            Assert.ThrowsException<LengthLimitExceededException>(() => new Bet("asd", "asd", "asdfasdfasdfdsafdsafdsafdsadsafds", "asd", "asd", 5));
        }
        
        [TestMethod]
        public void ConstructorSubtractStakeFromPlayersPoints()
        {
            User player = new User("Gipsz Jakab", "Delulu!0");
            player.MakeBet("Játék", "10", "Béla", "Pontjainak száma", 5);
            Assert.AreEqual(95, player.Points);
        }

        [TestMethod]
        public void ConstructorThrowsNotEnoughPointsExceptionIfPlayersPointsAreLessThanStake()
        {
            User player = new User("Gipsz Jakab", "Delulu!0");
            Assert.ThrowsException<NotEnoughPointsException>(() =>
                player.MakeBet("Játék", "10", "Béla", "Pontjainak száma", 110));
        }

        [TestMethod]
        public void IfStakeIsNotGreaterThan0ThrowNonPositiveStakeException()
        {
            User player = new User("Gipsz Jakab", "Delulu!0");
            Assert.ThrowsException<NonPositiveStakeException>(() =>
                new Bet(player.Name, "10", "Játék", "Béla", "Pontjainak száma", 0));
        }

        [TestMethod]
        public void BetsGivesBackDictionaryWhereBetsGroupedByGames()
        {
            User player = new User("Gipsz Jakab", "Delulu!0");
            User player2 = new User("Gipsz Jakab2", "Delulu!0");

            Bets bets = new();
            bets = (Bets)bets.AddItem(new Bet(player.Name, "Játék", "10", "Béla", "Pontjainak száma", 5));
            bets = (Bets)bets.AddItem(new Bet(player.Name, "Iskola", "4", "Béla", "Matek átlaga", 5));
            bets = (Bets)bets.AddItem(new Bet(player.Name, "Foci", "2", "Béla", "Lőtt gólok", 5));
            bets = (Bets)bets.AddItem(new Bet(player2.Name, "Iskola", "5", "Béla", "Matek átlaga", 5));
            bets = (Bets)bets.AddItem(new Bet(player2.Name, "Foci", "4", "Béla", "Lőtt gólok", 5));
            bets = (Bets)bets.AddItem(new Bet(player2.Name, "Foci", "5", "Joci", "Lőtt gólok", 5));

            Dictionary<string, List<Bet>> betsByGames = bets.BetsByGames;
            Assert.AreEqual(1, betsByGames["Játék"].Count);
            Assert.AreEqual(2, betsByGames["Iskola"].Count);
            Assert.AreEqual(3, betsByGames["Foci"].Count);
        }

        [TestMethod]
        public void PointDistributionAfterGameIsEnded()
        {
            var users = new Users();
            var player1 = new User("hululu", "Delulu!0");
            var player2 = new User("delulu", "Delulu!0");
            users = (Users)users.AddItem(player1);
            users = (Users)users.AddItem(player2);
            var bets = new Bets();

            Assert.AreEqual(100, player1.Points);
            Assert.AreEqual(100, player2.Points);
            var events = new List<Event> { new Event("asdasd", "hululu", "game") };
            var game = new Game("game", "organizer", events);
            Assert.AreEqual("", game.Events.ElementAt(0).Result);
            var result = new List<string>() { "result" };
            Assert.IsTrue(game.IsInProgress);
            bets = (Bets)bets.AddItem(player1.MakeBet("game", "result", "hululu", "asdasd", 5));
            bets = (Bets)bets.AddItem(player2.MakeBet("game", "asd", "hululu", "asdasd", 5));
            game.EndGame(result);
            users.DistributePoints(game, bets);
            Assert.AreEqual(95, player2.Points);
            Assert.AreEqual(112, player1.Points);
        }

        [TestMethod]
        public void BetsCanBeAddedWithoutPointsBeingDeducted()
        {
            var user = new User("jack", "Delulu!0");
            user.AddBet(new Bet("jack", "hululu", "bamm", "john", "delulu", 20));
            Assert.AreEqual(100, user.Points);
            Assert.AreEqual(1, user.PlacedBets.Items.Count());
        }

        [TestMethod]
        public void MultipleBetsOnTheSameSubjectAndEventThrowException()
        {
            User player = new User("hululu", "Delulu!0");

            Bets bets = new();
            bets = (Bets)bets.AddItem(new Bet(player.Name, "Game", "10", "Jack", "Number of points", 5));
            Assert.ThrowsException<DuplicateBetException>(() =>
                bets = (Bets)bets.AddItem(new Bet(player.Name, "Game", "4", "Jack", "Number of points", 5)));
        }
    }
}
