using _15puzzle.Boards;

namespace _15puzzle.States
{
    public class BFSState : IState
    {
        private IState previous;
        private Board board;
        private bool isWinning;
        private string previousMove;

        public override IState Previous { get => previous; set => previous = value; }
        public override Board Board15 { get => board; set => board = value; }
        public override bool IsWinning { get => isWinning; set => isWinning = value; }
        public override string PreviousMove { get => previousMove; set => previousMove = value; }
       
        public BFSState(Board board, IState previous, string previousMove)
        {
            this.Previous = previous;
            this.Board15 = board;
            this.IsWinning = false;
            this.PreviousMove = previousMove;
        }

        //DO NOT USE FOR THIS STATE!!!
        public override byte Depth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
