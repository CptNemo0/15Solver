using _15puzzle.Boards;
using _15puzzle.Fields;

namespace _15puzzle.Utility
{
    public class Checker
    {
        private IBoard board;
        private IPuzzleField[][] winningBoard;

        public Checker(Board board)
        {
            this.board = board;
            winningBoard = new PuzzleField[board.Height][];
            for (int i = 0; i < board.Height; i++)
            {
                winningBoard[i] = new PuzzleField[board.Width];
                for (int j = 0; j < board.Width; j++)
                {
                    winningBoard[i][j] = new PuzzleField((byte)(board.Height * i + j + 1));
                }
            }
            winningBoard[board.Height - 1][board.Width - 1].Value = 0;
            this.board = board;
        }

        public Checker(IBoard board, IPuzzleField[][] winningBoard)
        {
            this.board = board;
            this.winningBoard = winningBoard;
        }

        public bool isWinning()
        {
            bool retValue = false;

            if (winningBoard == board.Fields)
            {
                retValue = true;
            }

            return retValue;
        }
    }
}
