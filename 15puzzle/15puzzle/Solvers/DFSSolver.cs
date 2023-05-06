using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _15puzzle.Boards;
using _15puzzle.States;
using _15puzzle.Utility;
using System.Diagnostics;

namespace _15puzzle.Solvers
{
    public class DFSSolver : ISolver
    {
        private Stack<DFSState> stack = new Stack<DFSState>();
        private IState winningState;
        private Sorter sorter;
        private byte maxDepth;
        private Stopwatch hourglass;

        public override Stack<DFSState> Stack { get => stack; set => stack = value; }
        public override IState WinningState { get => winningState; set => winningState = value; }
        public override Sorter Sorter { get => sorter; set => sorter = value; }
        public byte MaxDepth { get => maxDepth; set => maxDepth = value; }
        public override Stopwatch Hourglass { get => hourglass; set => hourglass = value; }

        public DFSSolver(DFSState initialState, DFSState winningState, int moveOrder, byte maxDepth)
        {
            WinningState = winningState;
            MaxDepth = maxDepth;
            Stack = new Stack<DFSState>();
            Stack.Push(initialState);
            Sorter = new Sorter(moveOrder);
            hourglass = new Stopwatch();
        }

        //processedStates / visitedStates = 0,46504638
        public override List<DFSState> DFSsolve(ref int visitedStates, ref int processedStates, ref double elapsedTime)
        {
            hourglass.Start();
            List<DFSState> retValue = new List<DFSState>();
            Mover mover;
            DFSState state;
            string[] moves;

            while (stack.Count > 0)
            {
                state = stack.Pop();
                processedStates++;

                mover = new Mover(state.Board15);
                string ppm = state.PreviousMove;
                moves = mover.getPossibleMoves(ppm);
                visitedStates += moves.Length;
                sorter.sort(ref moves);
                DFSState[] childrenStates = new DFSState[moves.Length];

                if (state.Depth + 1 <= MaxDepth)
                {
                    for (int i = moves.Length - 1; i > -1; i--)
                    {
                        Board temp2 = new Board(state.Board15);
                        mover = new Mover(temp2);
                        mover.move(moves[i]);
                        childrenStates[i] = IState.CreateDFSState(temp2, state, moves[i], (byte)(state.Depth + 1));
                        //childrenStates[i] = new DFSState((byte)(state.Depth + 1), state, temp2, moves[i]);

                        if (winningState.Board15.Equals(childrenStates[i].Board15))
                        {
                            childrenStates[i].IsWinning = true;
                            visitedStates++;

                            //Console.WriteLine(visitedStates);
                            //Console.WriteLine("Found winner!");
                            hourglass.Stop();
                            elapsedTime = (double)hourglass.Elapsed.TotalMilliseconds;

                            DFSState winnerState = childrenStates[i];

                            while (true)
                            {
                                retValue.Add(winnerState);

                                //Console.WriteLine(winnerState.Depth);
                                winnerState = (DFSState)winnerState.Previous;
                                if (winnerState == null)
                                {
                                    break;
                                }
                            }
                            return retValue;

                        }
                        else
                        {
                            childrenStates[i].IsWinning = false;
                        }
                        stack.Push(childrenStates[i]);
                    }
                }
            }
            return retValue;
        }



        //DO NOT USE!!!!!!!!
        public override List<BFSState> BFSsolve(ref int visitedStates, ref int processedStates, ref double elapsedTime)
        {
            throw new NotImplementedException();
        }
        public override List<ASState> ASsolveMan(ref int visitedStates, ref int processedStates, ref double elapsedTime)
        {
            throw new NotImplementedException();
        }
        public override List<ASState> ASsolveHam(ref int visitedStates, ref int processedStates, ref double elapsedTime)
        {
            throw new NotImplementedException();
        }
        public override List<ASState> States { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override Queue<BFSState> Queue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override ASStateComparer Comparer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
