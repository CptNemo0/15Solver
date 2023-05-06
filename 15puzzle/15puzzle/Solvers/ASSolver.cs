using System;
using System.Collections;
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
    public class ASSolver : ISolver
    {
        private List<ASState> states = new List<ASState>();
        private IState winningState;
        private ASStateComparer comparer;
        private Stopwatch hourglass;

        public override List<ASState> States { get => states; set => states = value; }
        public override IState WinningState { get => winningState; set => winningState = value; }
        public override ASStateComparer Comparer { get => comparer; set => comparer = value; }
        public override Stopwatch Hourglass { get => hourglass; set => hourglass = value; }
        public ASSolver(ASState initialState, ASState winningState)
        {
            States = new List<ASState>();
            States.Add(initialState);
            WinningState = winningState;
            Comparer = new ASStateComparer();
            hourglass = new Stopwatch();
        }

        public override List<ASState> ASsolveMan(ref int visitedStates, ref int processedStates, ref double elapsedTime)
        {
            hourglass.Start();
            List<ASState> retValue = new List<ASState>();
            Mover mover;
            ASState state;
            string[] moves;

            while (States.Count > 0)
            {
                States.Sort(comparer);
                state = States[0];
                States.RemoveAt(0);
                processedStates++;

                mover = new Mover(state.Board15);
                string ppm = state.PreviousMove;
                moves = mover.getPossibleMoves(ppm);
                visitedStates += moves.Length;
                ASState[] childrenStates = new ASState[moves.Length];

                for (int i = 0; i < moves.Length; i++)
                {
                    Board temp2 = new Board(state.Board15);
                    mover = new Mover(temp2);
                    mover.move(moves[i]);
                    childrenStates[i] = IState.CreateASState(temp2, state, moves[i]);
                    //childrenStates[i] = new ASState(state, temp2, false, moves[i]);
                    childrenStates[i].evaluateStateMan();

                    if (winningState.Board15.Equals(childrenStates[i].Board15))
                    {
                        childrenStates[i].IsWinning = true;
                        visitedStates++;

                        //Console.WriteLine(visitedStates);
                        //Console.WriteLine("Found winner!");
                        hourglass.Stop();
                        elapsedTime = (double)hourglass.Elapsed.TotalMilliseconds;

                        ASState winnerState = childrenStates[i];

                        while (true)
                        {
                            retValue.Add(winnerState);

                            //Console.WriteLine(winnerState.Depth);
                            winnerState = (ASState)winnerState.Previous;
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
                    States.Add(childrenStates[i]);
                }

            }

            return retValue;
        }
        public override List<ASState> ASsolveHam(ref int visitedStates, ref int processedStates, ref double elapsedTime)
        {
            hourglass.Start();
            List<ASState> retValue = new List<ASState>();
            Mover mover;
            ASState state;
            string[] moves;

            while (States.Count > 0)
            {
                States.Sort(comparer);
                state = States[0];
                States.RemoveAt(0);
                processedStates++;

                mover = new Mover(state.Board15);
                string ppm = state.PreviousMove;
                moves = mover.getPossibleMoves(ppm);
                visitedStates += moves.Length;
                ASState[] childrenStates = new ASState[moves.Length];

                for (int i = 0; i < moves.Length; i++)
                {
                    Board temp2 = new Board(state.Board15);
                    mover = new Mover(temp2);
                    mover.move(moves[i]);
                    childrenStates[i] = IState.CreateASState(temp2, state, moves[i]);
                    //childrenStates[i] = new ASState(state, temp2, false, moves[i]);
                    childrenStates[i].evaluateStateHam();

                    if (winningState.Board15.Equals(childrenStates[i].Board15))
                    {
                        childrenStates[i].IsWinning = true;
                        visitedStates++;

                        //Console.WriteLine(visitedStates);
                        //Console.WriteLine("Found winner!");
                        hourglass.Stop();
                        elapsedTime = (double)hourglass.Elapsed.TotalMilliseconds;

                        ASState winnerState = childrenStates[i];

                        while (true)
                        {
                            retValue.Add(winnerState);

                            //Console.WriteLine(winnerState.Depth);
                            winnerState = (ASState)winnerState.Previous;
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
                    States.Add(childrenStates[i]);
                }

            }

            return retValue;
        }


        // DO NOT USE!!!
        public override List<BFSState> BFSsolve(ref int visitedStates, ref int processedStates, ref double elapsedTime)
        {
            throw new NotImplementedException();
        }
        public override List<DFSState> DFSsolve(ref int visitedStates, ref int processedStates, ref double elapsedTime)
        {
            throw new NotImplementedException();
        }
        public override Queue<BFSState> Queue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override Stack<DFSState> Stack { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override Sorter Sorter { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
