﻿// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Monopoly
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void GetPlayersListReturnCorrectList()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Tuple<string, int>[] expectedPlayers = new Tuple<string, int>[]
            {
                new Tuple<string, int>("Peter",6000),
                new Tuple<string, int>("Ekaterina",6000),
                new Tuple<string, int>("Alexander",6000)
            };
              Monopoly monopoly = new Monopoly(players);
              Tuple<string, int>[] actualPlayers = monopoly.GetPlayersList().ToArray();

            Assert.AreEqual(expectedPlayers, actualPlayers);
        }
        [Test]
        public void GetFieldsListReturnCorrectList()
        {
            Tuple<string, Type, int, bool>[] expectedCompanies =
                new Tuple<string, Type, int, bool>[]{
                new Tuple<string,Type,int,bool>("Ford",Type.AUTO,0,false),
                new Tuple<string,Type,int,bool>("MCDonald", Type.FOOD, 0, false),
                new Tuple<string,Type,int,bool>("Lamoda", Type.CLOTHER, 0, false),
                new Tuple<string,Type, int, bool>("Air Baltic",Type.TRAVEL,0,false),
                new Tuple<string, Type, int, bool>("Nordavia",Type.TRAVEL,0,false),
                new Tuple<string, Type, int, bool>("Prison",Type.PRISON,0,false),
                new Tuple<string, Type, int, bool>("MCDonald",Type.FOOD,0,false),
                new Tuple<string, Type, int, bool>("TESLA",Type.AUTO,0,false)
            };
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
          
            Monopoly monopoly = new Monopoly(players);
            Tuple<string, Type, int, bool>[] actualCompanies = monopoly.GetFieldsList().ToArray();
          
            Assert.AreEqual(expectedCompanies, actualCompanies);
        }
        [Test]
        public void PlayerBuyNoOwnedCompanies()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players);
            Tuple<string, Type, int, bool> x = monopoly.GetFieldByName("Ford");
            monopoly.Buy(1, x);
            Tuple<string, int> actualPlayer = monopoly.GetPlayerInfo(1);
            Tuple<string, int> expectedPlayer = new Tuple<string, int>("Peter", 5500);
            Assert.AreEqual(expectedPlayer, actualPlayer);
            Tuple<string, Type, int, bool> actualField = monopoly.GetFieldByName("Ford");
            Assert.AreEqual(1, actualField.Item3);
        }
        [Test]
        public void RentaShouldBeCorrectTransferMoney()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players);
            Tuple<string, Type, int, bool> x = monopoly.GetFieldByName("Ford");
            monopoly.Buy(1, x);
            x = monopoly.GetFieldByName("Ford");
            monopoly.Renta(2, x);
            Tuple<string, int> player1 = monopoly.GetPlayerInfo(1);
            Assert.AreEqual(5750, player1.Item2);
            Tuple<string, int> player2 = monopoly.GetPlayerInfo(2);
            Assert.AreEqual(5750, player2.Item2);
        }
    }
}
