using _15puzzle.Boards;
using _15puzzle.Fields;

namespace _15puzzle.Utility
{
    public class Checker
    {
        private Board board;

        public Checker(Board board)
        {
            this.Board = board;
        }

        public Board Board { get => board; set => board = value; }

        private int FindXPosition()
        {
            // start from bottom-right corner of matrix
            for (int i = board.Height - 1; i >= 0; i--)
            {
                for (int j = board.Width - 1; j >= 0; j--)
                {
                    if (board.Fields[i][j].Value == 0)
                    {
                        return board.Height - i;
                    }
                }
            }
            return -1;
        }

        private int GetInvCount(int[] arr)
        {
            int inv_count = 0;
            for (int i = 0; i < ((Board.Height * Board.Width) - 1); i++)
            {
                for (int j = i + 1; j < (Board.Height * Board.Width); j++)
                {
                    if (arr[j] != 0 && arr[i] != 0 && arr[i] > arr[j])
                        inv_count++;
                }
            }
            return inv_count;
        }

        public bool IsSolvable()
        {
            bool retValue = false;
            int[] arr = Board.Map();
            int invCount = GetInvCount(arr);
               
            if (board.Width % 2 == 1)
            {
                if(invCount % 2 == 0) 
                {
                    retValue = true;
                }
            }
            else 
            {
                int pos = FindXPosition();

                if (pos % 2 == 1)       //nieparzysty
                {
                    if(invCount % 2 == 0)
                    {
                        retValue = true;
                    }
                }
                else                    //parzysty
                {
                    if(invCount % 2 == 1)
                    {
                        retValue = true;
                    }
                }
            }
            return retValue;
        }
    }
}
