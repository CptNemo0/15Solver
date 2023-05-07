using _15puzzle.Boards;
using _15puzzle.Solvers;
using _15puzzle.States;
using _15puzzle.Utility;
using static System.Net.Mime.MediaTypeNames;

namespace _15puzzle
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            Console.WriteLine("God created Arrakis to train the faithful");

            byte WIDTH = 3;
            byte HEIGHT = 4;

            int visitedStates = 0;
            int processedStates = 0;
            double elapsedTime = 0;

            /*
            for(int i = 0;  i < 1000; i++) 
            {
                
                Board winningBoard = new Board(HEIGHT, WIDTH);
                Mover mover = new Mover(test);
                Shuffler shuffler = new Shuffler(test, mover);
                shuffler.shuffle(15);
            }
            */
            Board winningBoard = new Board(HEIGHT, WIDTH);
            Board test = new Board(HEIGHT, WIDTH);
            test.Fields[0][0].Value = 1;
            test.Fields[0][1].Value = 3;
            test.Fields[0][2].Value = 2;
            Checker checker = new Checker(test);
            Console.WriteLine(checker.IsSolvable());

            
            ASState testState = new ASState(test, null, null);
            ASState winningState = new ASState(winningBoard, null, null);

            ISolver solver = new ASSolver(testState, winningState);

            List<ASState> solution = solver.ASsolveHam(ref visitedStates, ref processedStates, ref elapsedTime);

            for(int i = solution.Count - 1; i > -1; i--)
            {
                solution[i].Board15.Print();
                Console.WriteLine(solution[i].PreviousMove);
            }
            Console.WriteLine("\n" +  solution.Count);
            Console.WriteLine(visitedStates);
            Console.WriteLine(processedStates);
            
        }
    }
}