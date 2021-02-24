using static src.Square;

namespace src
{
    internal class Board
    {
        private Player[] _playedSquares = new Player[9];
        private Square[][] _winningConditions = new Square[][] {
            new Square[] { TopLeft, TopCenter, TopRight }, 
            new Square[] { MiddleLeft, MiddleCenter, MiddleRight }, 
            new Square[] { BottomLeft, BottomCenter, BottomRight },
            new Square[] { TopLeft, MiddleLeft, BottomLeft },
            new Square[] { TopCenter, MiddleCenter, BottomCenter },
            new Square[] { TopLeft, MiddleLeft, BottomLeft },
            new Square[] { TopLeft, MiddleCenter, BottomRight },
            new Square[] { TopRight, MiddleCenter, BottomLeft },
        };

        public bool IsSquarePlayed(Square square)
        {
            return _playedSquares[(int) square] != Player.None;
        }

        public void PlaceMarker(Square square, Player player)
        {
            _playedSquares[(int) square] = player;
        }

        public Player GetPlayerAtSquare(Square square)
        {
            return _playedSquares[(int) square];
        }

        public bool HaveSamePlayer(Square first, Square second, Square third)
        {
            return GetPlayerAtSquare(first) != Player.None && 
                GetPlayerAtSquare(first) == GetPlayerAtSquare(second) &&
                   GetPlayerAtSquare(second) == GetPlayerAtSquare(third);
        }

        public Player GetWinner()
        {
            foreach (var winningCondition in _winningConditions)
            {
                if (HaveSamePlayer(winningCondition[0], winningCondition[1], winningCondition[2]))
                    return GetPlayerAtSquare(winningCondition[0]);
            }

            return Player.None;
        }
    }
}