using _15puzzle;
using _15puzzle.Boards;
using _15puzzle.Solvers;
using _15puzzle.States;
using Serialization;
using _15puzzle.Utility;
using System;
using System.Threading;
using System.Text;
using System.Globalization;

namespace GUI
{
    public partial class Form1 : Form
    {

        private string solution;
        private int moveCount;
        private int visitedStates;
        private int processedStates;
        private double timeElapsed;
        private int moveOrder;

        private Board board;
        private IState winningState;
        private IState initialState;

        private BFSSolver bfsSolver;
        private DFSSolver dfsSolver;
        private ASSolver asSolver;

        string mode;

        public Form1()
        {
            InitializeComponent();
            mode = "BFS";
            solution = "";
            moveCount = 0;
            visitedStates = 0;
            processedStates = 0;
            timeElapsed = 0;
            moveOrder = 10;
        }

        private void updateBoxes()
        {
            solutionBox.Text = solution;
            moveCountBox.Text = moveCount.ToString();
            visitedStatesBox.Text = visitedStates.ToString();
            processedStatesBox.Text = processedStates.ToString();
            timeBox.Text = timeElapsed.ToString() + " ms";
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            mode = "BFS";
            solution = "";
            moveCount = 0;
            visitedStates = 0;
            processedStates = 0;
            timeElapsed = 0;
            moveOrder = 10;
            solutionBox.Text = string.Empty;
            moveCountBox.Text = string.Empty;
            visitedStatesBox.Text = string.Empty;
            processedStatesBox.Text = string.Empty;
            timeBox.Text = string.Empty;

            List<Board> boards = new List<Board>();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Load puzzle!";
            openFileDialog.Filter = "Json files (*.json)|*.json";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                fileNameBox.Text = fileName;
                FileManager fileManager = new FileManager(fileName);
                boards = fileManager.readFile();
            }

            board = boards[0];
        }

        private void picker_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (picker.SelectedIndex)
            {
                case 0:
                    {
                        mode = "BFS";
                        break;
                    }

                case 1:
                    {
                        mode = "DFS";
                        break;
                    }
                case 2:
                    {
                        mode = "MAN";
                        moveOrder = 10;
                        break;
                    }
                case 3:
                    {
                        mode = "HAM";
                        moveOrder = 10;
                        break;
                    }
            }
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            switch (mode)
            {
                case "BFS":
                    {
                        Board winningBoard = new Board(board.Height, board.Width);
                        winningState = new BFSState(winningBoard, null, null);
                        initialState = new BFSState(board, null, null);
                        bfsSolver = new BFSSolver((BFSState)winningState, initialState, 1);
                        List<BFSState> solution = bfsSolver.BFSsolve(ref visitedStates, ref processedStates, ref timeElapsed);

                        StringBuilder stringBuilder = new StringBuilder();

                        for (int i = 0; i < solution.Count; i++)
                        {
                            if (solution[i].PreviousMove is not null)
                            {
                                stringBuilder.Append(solution[i].PreviousMove.ToString());
                            }

                            this.solution = stringBuilder.ToString();
                        }

                        this.moveCount = solution.Count;
                        updateBoxes();
                        break;
                    }
                case "DFS":
                    {
                        Board winningBoard = new Board(board.Height, board.Width);
                        winningState = new DFSState(winningBoard, null, null, 0);
                        initialState = new DFSState(board, null, null, 0);
                        dfsSolver = new DFSSolver((DFSState)initialState, (DFSState)winningState, 1, 20);
                        List<DFSState> solution = dfsSolver.DFSsolve(ref visitedStates, ref processedStates, ref timeElapsed);

                        StringBuilder stringBuilder = new StringBuilder();

                        for (int i = solution.Count - 1; i > -1; i--)
                        {
                            if (solution[i].PreviousMove is not null)
                            {
                                stringBuilder.Append(solution[i].PreviousMove.ToString());
                            }

                            this.solution = stringBuilder.ToString();
                        }

                        this.moveCount = solution.Count;
                        updateBoxes();
                        break;
                    }
                case "MAN":
                    {
                        Board winningBoard = new Board(board.Height, board.Width);
                        winningState = new ASState(winningBoard, null, null);
                        initialState = new ASState(board, null, null);
                        asSolver = new ASSolver((ASState)initialState, (ASState)winningState);
                        List<ASState> solution = asSolver.ASsolveMan(ref visitedStates, ref processedStates, ref timeElapsed);

                        StringBuilder stringBuilder = new StringBuilder();

                        for (int i = solution.Count - 1; i > -1; i--)
                        {
                            if (solution[i].PreviousMove is not null)
                            {
                                stringBuilder.Append(solution[i].PreviousMove.ToString());
                            }

                            this.solution = stringBuilder.ToString();
                        }

                        this.moveCount = solution.Count;
                        updateBoxes();
                        break;
                    }
                case "HAM":
                    {
                        Board winningBoard = new Board(board.Height, board.Width);
                        winningState = new ASState(winningBoard, null, null);
                        initialState = new ASState(board, null, null);
                        asSolver = new ASSolver((ASState)initialState, (ASState)winningState);
                        List<ASState> solution = asSolver.ASsolveHam(ref visitedStates, ref processedStates, ref timeElapsed);

                        StringBuilder stringBuilder = new StringBuilder();

                        for (int i = solution.Count - 1; i > -1; i--)
                        {
                            if (solution[i].PreviousMove is not null)
                            {
                                stringBuilder.Append(solution[i].PreviousMove.ToString());
                            }

                            this.solution = stringBuilder.ToString();
                        }

                        this.moveCount = solution.Count;
                        updateBoxes();
                        break;
                    }
            }
        }

        private void orderPicker_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (orderPicker.SelectedIndex)
            {
                case 0:
                    {
                        moveOrder = 3;
                        break;
                    }

                case 1:
                    {
                        moveOrder = 2;
                        break;
                    }
                case 2:
                    {
                        moveOrder = 4;
                        break;
                    }
                case 3:
                    {
                        moveOrder = 5;
                        break;
                    }
                case 4: 
                    {
                        moveOrder = 1;
                        break;
                    }
                case 5:
                    {
                        moveOrder = 0;
                        break;
                    }
                case 6:
                    {
                        moveOrder = 6;
                        break;
                    }
                case 7:
                    {
                        moveOrder = 7;
                        break;
                    }
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            string mo = string.Empty;
            switch (moveOrder)
            {
                case 0: 
                    {
                        mo = "RDUL";
                        break;
                    }
                case 1:
                    {
                        mo = "RDLU";
                        break;
                    }
                case 2:
                    {
                        mo = "DRUL";
                        break;
                    }
                case 3:
                    {
                        mo = "DRLU";
                        break;
                    }
                case 4:
                    {
                        mo = "LUDR";
                        break;
                    }
                case 5:
                    {
                        mo = "LURD";
                        break;
                    }
                case 6:
                    {
                        mo = "ULDR";
                        break;
                    }
                case 7:
                    {
                        mo = "ULRD";
                        break;
                    }
            }

            List<string> csvData = new List<string>();
            csvData.Add("Moves, Move Count, Move Order, Visited States, Processed States, Elapsed Time");
            StringBuilder sb = new StringBuilder();
            sb.Append(solution);
            sb.Append(", ");
            sb.Append((moveCount - 1).ToString());
            sb.Append(", ");
            sb.Append(mo);
            sb.Append(", ");
            sb.Append(visitedStates.ToString());
            sb.Append(", ");
            sb.Append(processedStates.ToString());
            sb.Append(", ");
            sb.Append(timeElapsed.ToString(CultureInfo.InvariantCulture));

            csvData.Add(sb.ToString());

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Data!";
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;

                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    // write each line of the CSV data to the file
                    foreach (string csvLine in csvData)
                    {
                        sw.WriteLine(csvLine);
                    }
                }
            }
        }
    }
}