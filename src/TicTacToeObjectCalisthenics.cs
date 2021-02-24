namespace src
{
    public class TicTacToeObjectCalisthenics
    {
        private Player _currentPlayer = Player.X; 
        private Board _board = new Board();

        public Player GetCurrentPlayer()
        {
            return _currentPlayer;
        }

        public void PlaceMarker(Square square)
        {
            if(_board.IsSquarePlayed(square))
                return;

            _board.PlaceMarker(square, _currentPlayer);
            
            AlternatePlayer();
        }

        private void AlternatePlayer()
        {
            if (_currentPlayer == Player.X)
            {
                _currentPlayer = Player.O;
                return;
            }

            _currentPlayer = Player.X;
        }

        public Player GetWinner()
        {
            return _board.GetWinner();
        }
    }
}
