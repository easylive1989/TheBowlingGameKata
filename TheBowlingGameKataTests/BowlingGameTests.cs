using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheBowlingGameKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBowlingGameKata.Tests
{
    [TestClass()]
    public class BowlingGameTests
    {
        [TestMethod()]
        public void NoPinFall()
        {
            var bowlingGame = GetBowlingGame();
            for (int i = 0; i < 10; i++)
            {
                bowlingGame.Roll(0);
            }
            Assert.AreEqual(0, bowlingGame.GetScore());
        }

        private BowlingGame GetBowlingGame()
        {
            return new BowlingGame();
        }

        [TestMethod]
        public void FourPinsEachRoll()
        {
            var bowlingGame = GetBowlingGame();
            for (int i = 0; i < 20; i++)
            {
                bowlingGame.Roll(4);
            }
            Assert.AreEqual(80, bowlingGame.GetScore());
        }

        [TestMethod]
        public void FivePinsEachRoll()
        {
            var bowlingGame = GetBowlingGame();
            for (int i = 0; i < 21; i++)
            {
                bowlingGame.Roll(5);
            }
            Assert.AreEqual(150, bowlingGame.GetScore());
        }

        [TestMethod]
        public void TenPinsEachRoll()
        {
            var bowlingGame = GetBowlingGame();
            for (int i = 0; i < 12; i++)
            {
                bowlingGame.Roll(10);
            }
            Assert.AreEqual(300, bowlingGame.GetScore());
        }

        [TestMethod]
        public void Complex()
        {
            var bowlingGame = GetBowlingGame();
            bowlingGame.Roll(1);
            bowlingGame.Roll(1);
            bowlingGame.Roll(1);
            bowlingGame.Roll(1);
            bowlingGame.Roll(10);
            bowlingGame.Roll(1);
            bowlingGame.Roll(1);
            bowlingGame.Roll(1);
            bowlingGame.Roll(1);
            bowlingGame.Roll(5);
            bowlingGame.Roll(5);
            bowlingGame.Roll(1);
            bowlingGame.Roll(1);
            bowlingGame.Roll(5);
            bowlingGame.Roll(5);
            bowlingGame.Roll(10);
            bowlingGame.Roll(1);
            bowlingGame.Roll(9);
            bowlingGame.Roll(5);

            Assert.AreEqual(88, bowlingGame.GetScore());
        }
    }
}