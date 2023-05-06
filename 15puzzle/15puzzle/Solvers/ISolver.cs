using _15puzzle.States;
using _15puzzle.Utility;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15puzzle.Solvers
{
    public abstract class ISolver
    {
        public abstract Queue<BFSState> Queue { get; set; }
        public abstract Stack<DFSState> Stack { get; set; }
        public abstract List<ASState> States { get; set; }
        public abstract IState WinningState { get; set; }
        public abstract Sorter Sorter { get; set; }
        public abstract ASStateComparer Comparer { get; set; }
        public abstract Stopwatch Hourglass { get; set; }

        public static ISolver CreateBFSSolver(BFSState initialState, BFSState winningState, int moveOrder)
        {
            return new BFSSolver(initialState, winningState, moveOrder);
        }

        public static ISolver CreateDFSSolver(DFSState initialState, DFSState winningState, int moveOrder, byte maxDepth)
        {
            return new DFSSolver(initialState, winningState, moveOrder, maxDepth);
        }


        public abstract List<BFSState> BFSsolve(ref int visitedStates, ref int processedStates, ref double elapsedTime);
        public abstract List<DFSState> DFSsolve(ref int visitedStates, ref int processedStates, ref double elapsedTime);
        public abstract List<ASState> ASsolveMan(ref int visitedStates, ref int processedStates, ref double elapsedTime);
        public abstract List<ASState> ASsolveHam(ref int visitedStates, ref int processedStates, ref double elapsedTime);

    }
}
