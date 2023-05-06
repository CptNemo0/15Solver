using _15puzzle;
using _15puzzle.Boards;
using _15puzzle.Solvers;
using _15puzzle.States;
using System.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Serialization
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            List<string> csvData = new List<string>();

            Console.WriteLine("BFS!");
            for (int shuffle = 1; shuffle < 8; shuffle++)
            {
                csvData = new List<string>();
                csvData.Add("Shuffle, Move Order, Moves, Move Count, Visited States, Processed States, Elapsed Time");
                string fileName = shuffle.ToString() + "moves";
                FileManager fileManager = new FileManager(fileName);
                List<Board> boards = fileManager.readFile();

                for (int moveOrder = 0; moveOrder < 8; moveOrder++)
                {
                    for (int i = 0; i < boards.Count; i++)
                    {
                        StringBuilder sb = new StringBuilder();
                        int visitedStates = 0;
                        int processedStates = 0;
                        double elapsedTime = 0;

                        Board winningBoard = new Board(4, 4);
                        BFSState winningState = new BFSState(winningBoard, null, null);
                        BFSState initialState = new BFSState(boards[i], null, null);

                        BFSSolver solver = new BFSSolver(initialState, winningState, moveOrder);

                        List<BFSState> solution = solver.BFSsolve(ref visitedStates, ref processedStates, ref elapsedTime);

                        sb.Append(shuffle.ToString() + ", ");

                        sb.Append(moveOrder.ToString() + ", ");

                        for (int j = solution.Count - 1; j > -1; j--)
                        {
                            sb.Append(solution[j].PreviousMove);
                        }

                        sb.Append(", " + (solution.Count - 1).ToString() + ", ");
                        sb.Append(visitedStates.ToString() + ", ");
                        sb.Append(processedStates.ToString() + ", ");
                        sb.Append(elapsedTime.ToString(CultureInfo.InvariantCulture));

                        csvData.Add(sb.ToString());
                    }

                    string outputName = "SolutionsBFS\\stats_shuffle_" + shuffle.ToString() + "_moveOrder_" + moveOrder.ToString() + ".csv";
                    using (StreamWriter sw = new StreamWriter(outputName))
                    {
                        // write each line of the CSV data to the file
                        foreach (string csvLine in csvData)
                        {
                            sw.WriteLine(csvLine);
                        }
                    }
                    csvData.Clear();
                    csvData.Add("Shuffle, Move Order, Moves, Move Count, Visited States, Processed States, Elapsed Time");
                }
            }

            Console.WriteLine("DFS!");
            for (int shuffle = 1; shuffle < 8; shuffle++) 
            {
                csvData = new List<string>();
                csvData.Add("Shuffle, Move Order, Moves, Move Count, Visited States, Processed States, Elapsed Time");
                string fileName = shuffle.ToString() + "moves";
                FileManager fileManager = new FileManager(fileName);
                List<Board> boards = fileManager.readFile();

                for (int moveOrder = 0; moveOrder < 8; moveOrder++)
                {
                    for (int i = 0; i < boards.Count; i++)
                    {
                        StringBuilder sb = new StringBuilder();
                        int visitedStates = 0;
                        int processedStates = 0;
                        double elapsedTime = 0;

                        Board winningBoard = new Board(4, 4);
                        DFSState winningState = new DFSState(winningBoard, null, null, 0);
                        DFSState initialState = new DFSState(boards[i], null, null, 0);

                        DFSSolver solver = new DFSSolver(initialState, winningState, moveOrder, 20);

                        List<DFSState> solution = solver.DFSsolve(ref visitedStates, ref processedStates, ref elapsedTime);

                        sb.Append(shuffle.ToString() + ", ");

                        sb.Append(moveOrder.ToString() + ", ");

                        for (int j = solution.Count - 1; j > -1; j--)
                        {
                            sb.Append(solution[j].PreviousMove);
                        }

                        sb.Append(", " + (solution.Count - 1).ToString() + ", ");
                        sb.Append(visitedStates.ToString() + ", ");
                        sb.Append(processedStates.ToString() + ", ");
                        sb.Append(elapsedTime.ToString(CultureInfo.InvariantCulture));

                        csvData.Add(sb.ToString());
                    }

                    string outputName = "SolutionsDFS\\stats_shuffle_" + shuffle.ToString() + "_moveOrder_" + moveOrder.ToString() + ".csv";
                    using (StreamWriter sw = new StreamWriter(outputName))
                    {
                        // write each line of the CSV data to the file
                        foreach (string csvLine in csvData)
                        {
                            sw.WriteLine(csvLine);
                        }
                    }
                    csvData.Clear();
                    csvData.Add("Shuffle, Move Order, Moves, Move Count, Visited States, Processed States, Elapsed Time");
                }
            }

            Console.WriteLine("MAN!");
            for (int shuffle = 1; shuffle < 8; shuffle++)
            {
                csvData = new List<string>();
                csvData.Add("Shuffle, Moves, Move Count, Visited States, Processed States, Elapsed Time");
                string fileName = shuffle.ToString() + "moves";
                FileManager fileManager = new FileManager(fileName);
                List<Board> boards = fileManager.readFile();

                
                    for (int i = 0; i < boards.Count; i++)
                    {
                        StringBuilder sb = new StringBuilder();
                        int visitedStates = 0;
                        int processedStates = 0;
                        double elapsedTime = 0;

                        Board winningBoard = new Board(4, 4);
                        ASState winningState = new ASState(winningBoard, null, null);
                        ASState initialState = new ASState(boards[i], null, null);

                        ASSolver solver = new ASSolver(initialState, winningState);

                        List<ASState> solution = solver.ASsolveMan(ref visitedStates, ref processedStates, ref elapsedTime);

                        sb.Append(shuffle.ToString() + ", ");

                        for (int j = solution.Count - 1; j > -1; j--)
                        {
                            sb.Append(solution[j].PreviousMove);
                        }

                        sb.Append(", " + (solution.Count - 1).ToString() + ", ");
                        sb.Append(visitedStates.ToString() + ", ");
                        sb.Append(processedStates.ToString() + ", ");
                        sb.Append(elapsedTime.ToString(CultureInfo.InvariantCulture));

                        csvData.Add(sb.ToString());
                    }

                    string outputName = "SolutionsMan\\stats_shuffle_" + shuffle.ToString() + ".csv";
                    using (StreamWriter sw = new StreamWriter(outputName))
                    {
                        // write each line of the CSV data to the file
                        foreach (string csvLine in csvData)
                        {
                            sw.WriteLine(csvLine);
                        }
                    }
                    csvData.Clear();
                    csvData.Add("Shuffle, Move Order, Moves, Move Count, Visited States, Processed States, Elapsed Time");
            }

            Console.WriteLine("HAM!");
            for (int shuffle = 1; shuffle < 8; shuffle++)
            {
                csvData = new List<string>();
                csvData.Add("Shuffle, Moves, Move Count, Visited States, Processed States, Elapsed Time");
                string fileName = shuffle.ToString() + "moves";
                FileManager fileManager = new FileManager(fileName);
                List<Board> boards = fileManager.readFile();


                for (int i = 0; i < boards.Count; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    int visitedStates = 0;
                    int processedStates = 0;
                    double elapsedTime = 0;

                    Board winningBoard = new Board(4, 4);
                    ASState winningState = new ASState(winningBoard, null, null);
                    ASState initialState = new ASState(boards[i], null, null);

                    ASSolver solver = new ASSolver(initialState, winningState);

                    List<ASState> solution = solver.ASsolveHam(ref visitedStates, ref processedStates, ref elapsedTime);

                    sb.Append(shuffle.ToString() + ", ");

                    for (int j = solution.Count - 1; j > -1; j--)
                    {
                        sb.Append(solution[j].PreviousMove);
                    }

                    sb.Append(", " + (solution.Count - 1).ToString() + ", ");
                    sb.Append(visitedStates.ToString() + ", ");
                    sb.Append(processedStates.ToString() + ", ");
                    sb.Append(elapsedTime.ToString(CultureInfo.InvariantCulture));

                    csvData.Add(sb.ToString());
                }

                string outputName = "SolutionsHam\\stats_shuffle_" + shuffle.ToString() + ".csv";
                using (StreamWriter sw = new StreamWriter(outputName))
                {
                    // write each line of the CSV data to the file
                    foreach (string csvLine in csvData)
                    {
                        sw.WriteLine(csvLine);
                    }
                }
                csvData.Clear();
                csvData.Add("Shuffle, Move Order, Moves, Move Count, Visited States, Processed States, Elapsed Time");
            }
        }
    }
}

