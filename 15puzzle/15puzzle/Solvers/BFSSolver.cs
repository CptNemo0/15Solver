using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _15puzzle.Boards;
using _15puzzle.States;
using _15puzzle.Utility;
using System.Diagnostics;

namespace _15puzzle.Solvers
{
    public class BFSSolver : ISolver
    {
        private Queue<BFSState> queue;
        private IState winningState;
        private Sorter sorter;
        private Stopwatch hourglass;

        public override Queue<BFSState> Queue { get => queue; set => queue = value; }
        public override IState WinningState { get => winningState; set => winningState = value; }
        public override Sorter Sorter { get => sorter; set => sorter = value; }
        public override Stopwatch Hourglass { get => hourglass; set => hourglass = value; }

        public BFSSolver(BFSState initialState, IState winningState, int moveOrder)
        {
            Queue = new Queue<BFSState>();
            Queue.Enqueue(initialState);
            WinningState = winningState;
            Sorter = new Sorter(moveOrder);
            hourglass = new Stopwatch();
        }

        //processedStates/visitedStates = 0.46
        public override List<BFSState> BFSsolve(ref int visitedStates, ref int processedStates, ref double elapsedTime)
        {
            hourglass.Start();
            List<BFSState> retValue = new List<BFSState>();
            Mover mover;
            BFSState state;
            string[] moves;

            while (queue.Count > 0)
            {
                state = queue.Dequeue();
                processedStates++;

                mover = new Mover(state.Board15);
                moves = mover.getPossibleMoves(state.PreviousMove);
                visitedStates += moves.Length;
                sorter.sort(ref moves);
                BFSState[] childrenStates = new BFSState[moves.Length];

                for (int i = 0; i < childrenStates.Length; i++)
                {
                    Board temp2 = new Board(state.Board15);
                    mover = new Mover(temp2);
                    mover.move(moves[i]);
                    childrenStates[i] = IState.CreateBFSState(temp2, state, moves[i]);
                    //childrenStates[i] = new BFSState(state, temp2, false, moves[i]);

                    if (winningState.Board15.Equals(childrenStates[i].Board15))
                    {
                        childrenStates[i].IsWinning = true;

                        //Console.WriteLine("Found winner!");
                        hourglass.Stop();
                        elapsedTime = (double)hourglass.Elapsed.TotalMilliseconds;
                        BFSState winnerState = childrenStates[i];

                        while (true)
                        {
                            retValue.Add(winnerState);
                            winnerState = (BFSState)winnerState.Previous;
                            if (winnerState == null)
                            {
                                break;
                            }
                        }
                        //Console.WriteLine(retValue.Count);

                        return retValue;

                    }
                    else
                    {
                        childrenStates[i].IsWinning = false;
                    }
                    queue.Enqueue(childrenStates[i]);
                }
            }

            return retValue;
        }

        
        
        //DO NOT USE WITH THIS SOLVER!!!
        public override List<DFSState> DFSsolve(ref int visitedStates, ref int processedStates, ref double elapsedTime)
        {
            throw new NotImplementedException();
        }
        public override List<ASState> ASsolveHam(ref int visitedStates, ref int processedStates, ref double elapsedTime)
        {
            throw new NotImplementedException();
        }
        public override List<ASState> ASsolveMan(ref int visitedStates, ref int processedStates, ref double elapsedTime)
        {
            throw new NotImplementedException();
        }
        public override List<ASState> States { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override ASStateComparer Comparer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override Stack<DFSState> Stack { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
    }
}

