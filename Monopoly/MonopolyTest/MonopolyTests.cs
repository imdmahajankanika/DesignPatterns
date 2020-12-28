using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using System;

namespace MonopolyTest
{
    [TestClass]
    public class MonopolyTest
    {
        Player p = new Player();
        [TestMethod]
        // Test whether rolling a dice gives numbers between 1-6 or not
        // Expected:- numbers obtained after dice rolling will be between 1-6
        public void RollDiceTest_IsInRange()
        {
            int dice1, dice2;
            for (int i = 0; i < 60; i++)
            {
                dice1 = p.RollDice()[0];
                dice2 = p.RollDice()[1];
                Assert.IsTrue(dice1 >= 1 && dice1 <= 6);
                Assert.IsTrue(dice2 >= 1 && dice2 <= 6);
            }
        }

        [TestMethod]
        // Test board positions are in the range 0-39. If a player reaches position 39 and still needs to move forward, he'll continue from position 0
        public void TestBoardPos_IsInRange()
        {
            int dice1 = p.RollDice()[0];
            int dice2 = p.RollDice()[1];
            int steps = dice1 + dice2;
            p.Pos = 39;
            Console.WriteLine("Current pos: {0}, steps to be moved fwd: {1}",p.Pos,steps);
            p.MoveAction(steps);
            Console.WriteLine("New pos: {0}", p.Pos);
            Assert.IsTrue(p.Pos<40);
        }

        [TestMethod]
        // Test if IsInJail==true after visiting jail
        public void Test_InJail()
        {
            p.VisitJail();
            Assert.IsTrue(p.IsInJail);
        }


    }
}
