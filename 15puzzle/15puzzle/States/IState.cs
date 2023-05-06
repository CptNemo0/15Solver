using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _15puzzle.Boards;

namespace _15puzzle.States
{
    public abstract class IState
    {
        public abstract IState Previous { get; set; }
        public abstract Board Board15 { get; set; }
        public abstract bool IsWinning { get; set; }
        public abstract string PreviousMove { get; set; }
        public abstract byte Depth { get; set; }
        public abstract int Value { get; set; }


        public static DFSState CreateDFSState(Board board, IState previousState, string previousMove, byte depth)
        {
            return new DFSState(board, previousState, previousMove, depth);
        }

        public static BFSState CreateBFSState(Board board, IState previousState, string previousMove)
        {
            return new BFSState(board, previousState, previousMove);
        }

        public static ASState CreateASState(Board board, IState previousState, string previousMove)
        {
            return new ASState(board, previousState, previousMove);
        }
    }
}
