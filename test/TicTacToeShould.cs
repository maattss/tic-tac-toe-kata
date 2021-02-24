using System;
using System.Linq;
using NUnit.Framework;
using src;

namespace test
{
    public class TicTacToeShould
    {
        private TicTacToe _ticTacToe;

        [SetUp]
        public void BeforeEachTest()
        {
            _ticTacToe = new TicTacToe();
        }

        [Test]
        public void ReturnsX_WhenGettingFirstPlayer()
        {
            string firstPlayer = _ticTacToe.GetCurrentPlayer();

            Assert.AreEqual("X", firstPlayer);
        }

        [Test]
        public void ReturnsO_WhenGettingSecondPlayer()
        {
            _ticTacToe.PlaceMarkerAt(1);

            string secondPlayer = _ticTacToe.GetCurrentPlayer();

            Assert.AreEqual("O", secondPlayer);
        }

        [Test]
        public void AlternatesPlayersOnEachTurn()
        {
            _ticTacToe.PlaceMarkerAt(1);
            _ticTacToe.PlaceMarkerAt(2);

            string currentPlayer = _ticTacToe.GetCurrentPlayer();

            Assert.AreEqual("X", currentPlayer);
        }

        [Test]
        public void PlayersCannotPlayOnAlreadyPlayedSquare()
        {
            _ticTacToe.PlaceMarkerAt(1);
            _ticTacToe.PlaceMarkerAt(1);

            string currentPlayer = _ticTacToe.GetCurrentPlayer();

            Assert.AreEqual("O", currentPlayer);
        }

        [Test]
        public void PlayersCannotPlayOnAlreadyPlayedSquare2()
        {
            _ticTacToe.PlaceMarkerAt(1);
            _ticTacToe.PlaceMarkerAt(2);
            _ticTacToe.PlaceMarkerAt(1);

            string currentPlayer = _ticTacToe.GetCurrentPlayer();

            Assert.AreEqual("X", currentPlayer);
        }

        [TestCase("O", new[] { 6, 0, 3, 1, 4, 2 })]
        [TestCase("X", new[] { 0, 3, 1, 4, 2 })]
        [TestCase("X", new[] { 3, 6, 4, 7, 5 })]
        [TestCase("X", new[] { 6, 3, 7, 4, 8 })]
        public void ThreeIdenticalMarkersSameRowWins(string expectedWinner, int[] squares)
        {
            foreach (var square in squares)
            {
                _ticTacToe.PlaceMarkerAt(square);
            }

            string winner = _ticTacToe.GetWinner();

            Assert.AreEqual(expectedWinner, winner);
        }

        [TestCase("O", new[] { 0, 1, 3, 4, 8, 7 })]
        [TestCase("X", new[] { 0, 1, 3, 4, 6 })]
        public void ThreeIdenticalMarkersSameColumnWins(string expectedWinner, int[] squares)
        {
            foreach (var square in squares)
            {
                _ticTacToe.PlaceMarkerAt(square);
            }

            string winner = _ticTacToe.GetWinner();

            Assert.AreEqual(expectedWinner, winner);
        }

        [TestCase("O", new[] { 0, 2, 1, 4, 3, 6 })]
        [TestCase("X", new[] { 0, 1, 4, 2, 8 })]
        public void ThreeIdenticalMarkersDiagonallyWins(string expectedWinner, int[] squares)
        {
            foreach (var square in squares)
            {
                _ticTacToe.PlaceMarkerAt(square);
            }

            string winner = _ticTacToe.GetWinner();

            Assert.AreEqual(expectedWinner, winner);
        }

        [TestCase("", new[] { 1, 0, 4, 3, 5, 2, 6, 7, 8 })]
        public void MarkersInAllSquaresIsTie(string expectedWinner, int[] squares)
        {
            foreach (var square in squares)
            {
                _ticTacToe.PlaceMarkerAt(square);
            }

            string winner = _ticTacToe.GetWinner();

            Assert.AreEqual(expectedWinner, winner);
        }

    }
}