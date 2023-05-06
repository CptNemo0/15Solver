using _15puzzle.Boards;
using _15puzzle.Solvers;
using _15puzzle.States;
using _15puzzle.Utility;

namespace _15puzzle
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            Console.WriteLine("God created Arrakis to train the faithful");

            byte WIDTH = 4;
            byte HEIGHT = 4;

            int visitedStates = 0;
            int processedStates = 0;
            double elapsedTime = 0;


            Board test = new Board(HEIGHT, WIDTH);
            Board winningBoard = new Board(HEIGHT, WIDTH);
            Mover mover = new Mover(test);
            Shuffler shuffler = new Shuffler(test, mover);
            shuffler.shuffle(15);

            ASState testState = new ASState(test, null, null);
            ASState winningState = new ASState(winningBoard, null, null);

            ISolver solver = new ASSolver(testState, winningState);

            List<ASState> solution = solver.ASsolveHam(ref visitedStates, ref processedStates, ref elapsedTime);

            for(int i = solution.Count - 1; i > -1; i--)
            {
                solution[i].Board15.Print();
                Console.WriteLine(solution[i].PreviousMove);
            }
            Console.WriteLine(visitedStates);
            Console.WriteLine(processedStates);
        }
    }
}