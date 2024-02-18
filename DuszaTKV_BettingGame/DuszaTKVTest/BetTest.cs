using DuszaTKVGameLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuszaTKVTest
{
    [TestClass]
    public class BetTest
    {
        [TestMethod]
        public void InitWithConstructorAndReturnsProperToString()
        {
            User player = new User("Gipsz Jakab", "jelszó");
            Bet bet = player.MakeBet("Játék", "10", "Béla", "Pontjainak száma", 5);
            Assert.AreEqual("Gipsz Jakab;Játék;10;Béla;Pontjainak száma;5", bet.ToString());
        }

        [TestMethod]
        public void ConstructorSubtractStakeFromPlayersPoints()
        {
            User player = new User("Gipsz Jakab", "jelszó");
            player.MakeBet("Játék", "10", "Béla", "Pontjainak száma", 5);
            Assert.AreEqual(95, player.Points);
        }
        
        [TestMethod]
        public void ConstructorThrowsNotEnoughPointsExceptionIfPlayersPointsAreLessThanStake()
        {
            User player = new User("Gipsz Jakab", "jelszó", 5);
            Assert.ThrowsException<NotEnoughPointsException>(()=> player.MakeBet("Játék", "10", "Béla", "Pontjainak száma", 10));
        }

        [TestMethod]
        public void IfStakeIsNotGreaterThan0ThrowNonPositiveStakeException()
        {
            User player = new User("Gipsz Jakab", "jelszó");
            Assert.ThrowsException<NonPositiveStakeException>(() => new Bet(player.Name, "10", "Játék", "Béla", "Pontjainak száma", 0));
        }

        [TestMethod]
        public void BetsGivesBackDirectoryWhereBetsGroupedByGames()
        {
            User player = new User("Gipsz Jakab", "jelszó");
            
            Bets bets = new();
            bets.AllBets.Add(new Bet(player.Name, "Játék", "10", "Béla", "Pontjainak száma", 5));
            bets.AllBets.Add(new Bet(player.Name, "Iskola", "5", "Béla", "Matek átlaga", 5));
            bets.AllBets.Add(new Bet(player.Name, "Iskola", "4", "Béla", "Matek átlaga", 5));
            bets.AllBets.Add(new Bet(player.Name, "Foci", "2", "Béla", "Lőtt gólok", 5));
            bets.AllBets.Add(new Bet(player.Name, "Foci", "4", "Béla", "Lőtt gólok", 5));
            bets.AllBets.Add(new Bet(player.Name, "Foci", "5", "Béla", "Lőtt gólok", 5));

            Dictionary<string, List<Bet>> betsByGames = bets.BetsByGames;
            Assert.AreEqual(1, betsByGames["Játék"].Count);
            Assert.AreEqual(2, betsByGames["Iskola"].Count);
            Assert.AreEqual(3, betsByGames["Foci"].Count);
        }
    }
}
