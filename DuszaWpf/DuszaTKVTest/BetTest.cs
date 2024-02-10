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
            User organiser = new User("Sanyi", "jelszó");
            User subject = new User("Béla", "jelszó");
            User player = new User("Gipsz Jakab", "jelszó");
            Users subjects = new Users();
            subjects.AllUsers.Add(subject);
            Game jatek = new Game("Játék",ref organiser, subjects, new List<string>() {"Pontjainak száma"});
            
            Bet bet = new Bet(ref player, jatek, "Béla", "Pontjainak száma", "10", 5);
            Assert.AreEqual("Gipsz Jakab;Játék;10;Béla;Pontjainak száma;5", bet.ToString());
        }

        [TestMethod]
        public void ConstructorSubtractStakeFromPlayersPoints()
        {
            User organiser = new User("Sanyi", "jelszó");
            User subject = new User("Béla", "jelszó");
            User player = new User("Gipsz Jakab", "jelszó");
            Users subjects = new Users();
            subjects.AllUsers.Add(subject);
            Game jatek = new Game("Játék", ref organiser, subjects, new List<string>() { "Pontjainak száma" });

            Bet bet = new Bet(ref player, jatek, "Béla", "Pontjainak száma", "10", 5);
            Assert.AreEqual(95, bet.Player.Points);
        }
        
        [TestMethod]
        public void ConstructorThrowsNotEnoughPointsExceptionIfPlayersPointsAreLessThanStake()
        {
            User organiser = new User("Sanyi", "jelszó");
            User subject = new User("Béla", "jelszó");
            User player = new User("Gipsz Jakab", "jelszó", 5);
            Users subjects = new Users();
            subjects.AllUsers.Add(subject);
            Game jatek = new Game("Játék", ref organiser, subjects, new List<string>() { "Pontjainak száma" });

            Assert.ThrowsException<NotEnoughPointsException>(()=>new Bet(ref player, jatek, "Béla", "Pontjainak száma", "10", 10));
        }

        [TestMethod]
        public void IfStakeIsNotGreaterThan0ThrowNonPositiveStakeException()
        {
            User organiser = new User("Sanyi", "jelszó");
            User subject = new User("Béla", "jelszó");
            User player = new User("Gipsz Jakab", "jelszó");
            Users subjects = new Users();
            subjects.AllUsers.Add(subject);
            Game jatek = new Game("Játék", ref organiser, subjects, new List<string>() { "Pontjainak száma" });

            Assert.ThrowsException<NonPositiveStakeException>(() => new Bet(ref player, jatek, "Béla", "Pontjainak száma", "10", 0));
        }

        [TestMethod]
        public void BetsGivesBackDirectoryWhereBetsGroupedByGames()
        {
            User organiser = new User("Sanyi", "jelszó");
            User subject = new User("Béla", "jelszó");
            User player = new User("Gipsz Jakab", "jelszó");
            Users subjects = new Users();
            subjects.AllUsers.Add(subject);

            Game jatek = new Game("Játék", ref organiser, subjects, new List<string>() { "Pontjainak száma" });
            Game iskola = new Game("Iskola", ref organiser, subjects, new List<string>() { "Matek átlaga" });
            Game foci = new Game("Foci", ref organiser, subjects, new List<string>() { "Lőtt gólok" });

            Bets bets = new();
            bets.AllBets.Add(new Bet(ref player, jatek, "Béla", "Pontjainak száma", "10", 5));
            bets.AllBets.Add(new Bet(ref player, iskola, "Béla", "Matek átlaga", "5", 5));
            bets.AllBets.Add(new Bet(ref player, iskola, "Béla", "Matek átlaga", "4", 5));
            bets.AllBets.Add(new Bet(ref player, foci, "Béla", "Lőtt gólok", "2", 5));
            bets.AllBets.Add(new Bet(ref player, foci, "Béla", "Lőtt gólok", "4", 5));
            bets.AllBets.Add(new Bet(ref player, foci, "Béla", "Lőtt gólok", "5", 5));

            Dictionary<string, List<Bet>> betsByGames = bets.BetsByGames;
            Assert.AreEqual(1, betsByGames["Játék"].Count);
            Assert.AreEqual(2, betsByGames["Iskola"].Count);
            Assert.AreEqual(3, betsByGames["Foci"].Count);
        }
    }
}
