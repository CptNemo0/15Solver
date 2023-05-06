using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _15puzzle.Boards;
using _15puzzle.States;

namespace _15puzzle
{
    public class DFSState : IState
    {
        private IState previous;
        private Board board;
        private bool isWinning;
        private string previousMove;
        private byte depth;
        
        public override IState Previous { get => previous; set => previous = value; }
        public override Board Board15 { get => board; set => board = value; }
        public override bool IsWinning { get => isWinning; set => isWinning = value; }
        public override string PreviousMove { get => previousMove; set => previousMove = value; }
        public override byte Depth { get => depth; set => depth = value; }
        
        public DFSState(Board board, IState prevoiusState, string previousMove, byte depth)
        {
            this.Depth = depth;
            this.Previous = prevoiusState;
            this.Board15 = board;
            this.IsWinning = false;
            this.PreviousMove = previousMove;
        }

        // DO NOT USE FOR THIS STATE!!!
        public override int Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
