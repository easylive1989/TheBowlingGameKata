using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheBowlingGameKata.Tests
{
    [TestClass()]
    public class BowlingGameTests
    {
        private BowlingGame _bowlingGame;

        [TestInitialize]
        public void SetUp()
        {
            _bowlingGame = new BowlingGame();
        }

        [TestMethod]
        public void AllOne()
        {
            RollMany(20, 1);

            Assert.AreEqual(20, _bowlingGame.GetScore());
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                _bowlingGame.Roll(pins);
            }
        }

        [TestMethod]
        public void AllZero()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, _bowlingGame.GetScore());
        }

        [TestMethod]
        public void OneSpare()
        {
            RollSpare();
            _bowlingGame.Roll(3);
            RollMany(17, 0);
            Assert.AreEqual(16, _bowlingGame.GetScore());
        }

        private void RollSpare()
        {
            _bowlingGame.Roll(5);
            _bowlingGame.Roll(5);
        }
        [TestMethod]
        public void OneStrike()
        {
            RollStrike();
            _bowlingGame.Roll(3);
            _bowlingGame.Roll(4);
            RollMany(16, 0);
            Assert.AreEqual(24, _bowlingGame.GetScore());
        }

        private void RollStrike()
        {
            _bowlingGame.Roll(10);
        }

        [TestMethod]
        public void AllStrike()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, _bowlingGame.GetScore());
        }
    }
}