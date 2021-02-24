namespace src
{
    public class TicTacToe
    {
        private string _currentPlayer = "X";
        private string[] _playedSquares = new string[9];

        public string GetCurrentPlayer()
        {
            return _currentPlayer;
        }

        public void PlaceMarkerAt(int square)
        {
            if (!string.IsNullOrWhiteSpace(_playedSquares[square]))
            {
                return;
            }

            _playedSquares[square] = _currentPlayer;

            if (_currentPlayer == "X")
            {
                _currentPlayer = "O";
            }
            else
            {
                _currentPlayer = "X";
            }
        }

        public string GetWinner()
        {
            var horizontalWinner = GetWinnerHorizontal();
            if (horizontalWinner != null) return horizontalWinner;

            var verticalWinner = GetWinnerVertical();
            if (verticalWinner != null) return verticalWinner;

            var diagonalWinner = GetWinnerDiagonally();
            if (diagonalWinner != null) return diagonalWinner;

            return string.Empty;
        }

        private string GetWinnerDiagonally()
        {
            if (_playedSquares[0] != null && 
                _playedSquares[0] == _playedSquares[4] && 
                _playedSquares[4] == _playedSquares[8])
            {
                return _playedSquares[0];
            }

            if (_playedSquares[2] != null && 
                _playedSquares[2] == _playedSquares[4] && 
                _playedSquares[4] == _playedSquares[6])
            {
                return _playedSquares[2];
            }
            return null;
        }

        private string GetWinnerVertical()
        {
            for (var columnStartIndex = 0; columnStartIndex < 3; columnStartIndex++)
            {
                if (_playedSquares[columnStartIndex] != null && 
                    _playedSquares[columnStartIndex] == _playedSquares[columnStartIndex + 3] && 
                    _playedSquares[columnStartIndex + 3] == _playedSquares[columnStartIndex + 6])
                {
                    return _playedSquares[columnStartIndex];
                }
            }
            return null;
        }

        private string GetWinnerHorizontal()
        {
            for (var rowStartIndex = 0; rowStartIndex < 9; rowStartIndex += 3)
            {
                if (_playedSquares[rowStartIndex] != null && 
                    _playedSquares[rowStartIndex] == _playedSquares[rowStartIndex + 1] && 
                    _playedSquares[rowStartIndex + 1] == _playedSquares[rowStartIndex + 2])
                {
                    return _playedSquares[rowStartIndex];
                }
            }
            return null;
        }
    }
}
