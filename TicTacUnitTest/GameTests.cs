using AutoMoq;
using NUnit.Framework;
using TicTacToeLogic.Classes;

namespace TicTacUnitTest
{
    [TestFixture]
    public class GameTests
    {
        private AutoMoqer _Moker;
        private Game _Game;
        [SetUp]
        public void SetUp()
        {
            _Moker = new AutoMoqer();
            _Game = _Moker.Create<Game>();
        }
        [Test]
        public void SetNextTurnTest()
        {
            _Game.SetNextTurn();
            Assert.That(_Game.GetCurrentPlayer(), Is.EqualTo(-1));
        }
        [Test]
        public void UpdateSquareTest()
        {
            // Test if update blank square is true
            Assert.That(_Game.UpdateSquare(0, 0), Is.EqualTo(true));

            // Test if square got set to the correct player
            Assert.That(_Game.GetBoard()[0, 0], Is.EqualTo(1));

            // Test if updating an occupied sqaure is false
            Assert.That(_Game.UpdateSquare(0, 0), Is.EqualTo(false));
        }
        [Test]
        // Vertical
        [TestCase(0, 0, 0, 1, 0, 2, TestName = "Left Vertical Win")]
        [TestCase(1, 0, 1, 1, 1, 2)]
        [TestCase(2, 0, 2, 1, 2, 2)]
        // Horizontal
        [TestCase(0, 0, 1, 0, 2, 0)]
        [TestCase(0, 1, 1, 1, 2, 1)]
        [TestCase(0, 2, 1, 2, 2, 2)]
        // Diagonal
        [TestCase(0, 0, 1, 1, 2, 2)]
        [TestCase(2, 0, 1, 1, 0, 2)]


        public void DidLastMoveWinTestSuccess(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            _Game.UpdateSquare(x1, y1);
            _Game.UpdateSquare(x2, y2);
            _Game.UpdateSquare(x3, y3);
            Assert.That(_Game.DidLastMoveWin(), Is.EqualTo(true));
        }
    }
}
