using _15puzzle.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaD
{
    public class Data
    {
        public Data() { }

        public void SolveAndGenerateDataBFS(List<Board> boards, int shuffleMoves) 
        {
            Board currentBoard = new Board(4, 4);

            for (int i = 0 ; i < boards.Count; i++) 
            {
                currentBoard = boards[i];
                Board winningBoard = new Board(currentBoard.Height, currentBoard.Width);

                // height, width, shuffleMoves, BFSmoves, BFStime, DFSmoves, DFStime, DFSdepth, MANmoves, MANtime, HAMmoves, HAMtime
            }
        }
    }
}
