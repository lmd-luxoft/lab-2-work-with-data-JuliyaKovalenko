// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Monopolia2017
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void GetPlayersListReturnCorrectList()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            List<Players> expectedPlayers = new List<Players>
            {
                new Players("Peter",0,6000),
                new  Players("Ekaterina",1,6000),
                new  Players("Alexander",2,6000)
            };
            Monopoly monopoly = new Monopoly(players, 3);
            List<Players> actualPlayers = monopoly.GetPlayersList();

            Assert.AreEqual(expectedPlayers, actualPlayers);


        }
        [Test]
        public void GetFieldsListReturnCorrectList()
        {
                List<Goods> expectedCompanies = new List<Goods>()
                {
                    new Goods("Ford",new  AUTO (), 0),
                    new Goods("MCDonald",new FOOD(), 0),
                    new Goods("Lamoda", new CLOTHER(), 3),
                     new Goods("Air Baltic", new TRAVEL(), 0),
                     new Goods("Nordavia", new TRAVEL(), 0),
                    new Goods("Prison", new PRISON(), 0),
                     new Goods("MCDonald", new FOOD(), 0),
                      new Goods("TESLA", new AUTO(), 0),
                };

        string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };

        Monopoly monopoly = new Monopoly(players, 3);

        List<Goods> actualCompanies = monopoly.GetFieldsList();

        Assert.AreEqual(expectedCompanies, actualCompanies);
        }

        [Test]
        public void PlayerBuyNoOwnedCompanies()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players, 3);

           string  expectedField = "Ford";
           
            Goods x = monopoly.GetFieldByName(expectedField);

            monopoly.Buy(0, x);

            Players actualPlayer = monopoly.GetPlayerInfo(0);
            Players expectedPlayer = new Players("Peter",0, 5500);

            Assert.AreEqual(expectedPlayer, actualPlayer);

            Goods actualField = monopoly.GetFieldByName("Ford");
            //we have chainged the owner 
           // Assert.AreEqual(expectedField, actualField.Name);

            Assert.AreEqual(actualField.Owner, 0);
        }

        [Test]
        public void PlayerBuyOwnedCompanies()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players, 3);

            string expectedField = "Lamoda";

            Goods x = monopoly.GetFieldByName(expectedField);

            bool expected = false;
            bool actualresult=monopoly.Buy(1, x);

    
            Assert.AreEqual(expected, actualresult);
        }

        [Test]
        public void RentaShouldBeCorrectTransferMoney()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players, 3);
            Goods x = monopoly.GetFieldByName("Ford");
            monopoly.Buy(1, x);
            x = monopoly.GetFieldByName("Ford");
            monopoly.Renta(2, x);

            Players player1 = monopoly.GetPlayerInfo(1);
            Assert.AreEqual(5750, player1.Cash);
            Players player2 = monopoly.GetPlayerInfo(2);

            Assert.AreEqual(5750, player2.Cash);
        }
    }
}
