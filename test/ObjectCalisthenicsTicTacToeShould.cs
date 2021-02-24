using System;
using System.Linq;
using NUnit.Framework;
using src;
using static src.Square;

namespace test
{
    public class ObjectCalisthenicsTicTacToeShould
    {
        private TicTacToeObjectCalisthenics _ticTacToe;

        [SetUp]
        public void BeforeEachTest()
        {
            _ticTacToe = new TicTacToeObjectCalisthenics();
        }

        [Test]
        public void MakesXTheFirstPlayer()
        {
            var player = _ticTacToe.GetCurrentPlayer();

            Assert.AreEqual(Player.X, player);
        }

        [Test]
        public void MakesOTheSecondPlayer()
        {
            _ticTacToe.PlaceMarker(TopLeft);

            var player = _ticTacToe.GetCurrentPlayer();

            Assert.AreEqual(Player.O, player);
        }

        [Test]
        public void AlternatesBetweenPlayers()
        {
            _ticTacToe.PlaceMarker(TopLeft);
            _ticTacToe.PlaceMarker(TopCenter);

            var player = _ticTacToe.GetCurrentPlayer();

            Assert.AreEqual(Player.X, player);
        }

        [TestCase(Player.O, new[] { TopLeft, TopLeft })]
        [TestCase(Player.X, new[] { TopLeft,TopCenter,TopRight,MiddleLeft, TopLeft })]
        public void PlayerCannotPlayOnAnAlreadyPlayedSquare(Player expectedPlayer, Square[] playedSquares)
        {
            foreach (var square in playedSquares)
            {
                _ticTacToe.PlaceMarker(square);
            }

            var player = _ticTacToe.GetCurrentPlayer();
            
            Assert.AreEqual(expectedPlayer, player);
        }

        [TestCase(Player.X, new[] { TopLeft, BottomCenter, MiddleLeft, BottomRight, BottomLeft })]
        [TestCase(Player.X, new[] { TopLeft, BottomLeft, MiddleCenter, BottomCenter, BottomRight })]
        [TestCase(Player.X, new[] { TopLeft, BottomLeft, TopCenter, BottomCenter, TopRight })]
        [TestCase(Player.O, new[] { MiddleLeft, TopLeft, BottomLeft, TopCenter, BottomCenter, TopRight })]
        [TestCase(Player.X, new[] { MiddleLeft, TopLeft, MiddleCenter, TopCenter, MiddleRight })]
        [TestCase(Player.X, new[] { BottomLeft, TopLeft, BottomCenter, TopCenter, BottomRight })]
        public void CheckForWinners(Player expectedWinner, Square[] playedSquares )
        {
            foreach (var square in playedSquares)
            {
                _ticTacToe.PlaceMarker(square);
            }
            
            var winner = _ticTacToe.GetWinner();
            
            Assert.AreEqual(expectedWinner,winner );
        }
    }
}