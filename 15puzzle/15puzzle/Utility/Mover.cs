using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using _15puzzle.Boards;

namespace _15puzzle.Utility
{
    public class Mover
    {
        private IBoard board;
        private string lastMove;
        private Dictionary<string, string> reverse;

        public IBoard Board { get => board; set => board = value; }
        public string LastMove { get => lastMove; set => lastMove = value; }
        public Dictionary<string, string> Reverse { get => reverse; set => reverse = value; }

        public Mover(Board board)
        {
            Reverse = new Dictionary<string, string>
            {
                { "U", "D" },
                { "D", "U" },
                { "R", "L" },
                { "L", "R" },
                { " ", " " }
            };
            this.Board = board;
            LastMove = " ";
        }

        public string[] getPossibleMoves(string previousMove)
        {
            Vector2 posistionOfZero = Board.FindZero();
            string[] retValue = new string[1];

            if (posistionOfZero.X > 0 && posistionOfZero.X < Board.Height - 1 && posistionOfZero.Y > 0 && posistionOfZero.Y < Board.Width - 1)
            {
                if (previousMove == null)
                {
                    retValue = new string[4];
                    retValue[0] = "L";
                    retValue[1] = "R";
                    retValue[2] = "U";
                    retValue[3] = "D";
                }
                else
                {
                    retValue = new string[3];
                    Queue<string> moves = new Queue<string>();
                    moves.Enqueue("L");
                    moves.Enqueue("R");
                    moves.Enqueue("U");
                    moves.Enqueue("D");
                    string move = "";
                    byte a = 0;
                    byte mc = (byte)moves.Count;
                    for (int i = 0; i < mc; i++)
                    {
                        move = moves.Dequeue();
                        if (move != Reverse[previousMove] && a < retValue.Length)
                        {
                            retValue[a] = move;
                            a = (byte)(a + 1);
                        }
                    }
                }
            }
            else if (posistionOfZero.X == 0 && posistionOfZero.Y == 0)
            {
                if (previousMove == null)
                {
                    retValue = new string[2];
                    retValue[0] = "R";
                    retValue[1] = "D";
                }
                else
                {
                    retValue = new string[1];
                    Queue<string> moves = new Queue<string>();
                    moves.Enqueue("R");
                    moves.Enqueue("D");
                    string move = "";
                    byte a = 0;
                    byte mc = (byte)moves.Count;
                    for (int i = 0; i < mc; i++)
                    {
                        move = moves.Dequeue();
                        if (move != Reverse[previousMove] && a < retValue.Length)
                        {
                            retValue[a] = move;
                            a = (byte)(a + 1);
                        }
                    }
                }
            }
            else if (posistionOfZero.X == 0 && posistionOfZero.Y == Board.Width - 1)
            {
                if (previousMove == null)
                {
                    retValue = new string[2];
                    retValue[0] = "L";
                    retValue[1] = "D";
                }
                else
                {
                    retValue = new string[1];
                    Queue<string> moves = new Queue<string>();
                    moves.Enqueue("L");
                    moves.Enqueue("D");
                    string move = "";
                    byte a = 0;
                    byte mc = (byte)moves.Count;
                    for (int i = 0; i < mc; i++)
                    {
                        move = moves.Dequeue();
                        if (move != Reverse[previousMove] && a < retValue.Length)
                        {
                            retValue[a] = move;
                            a = (byte)(a + 1);
                        }
                    }
                }

            }
            else if (posistionOfZero.X == Board.Height - 1 && posistionOfZero.Y == Board.Width - 1)
            {
                if (previousMove == null)
                {
                    retValue = new string[2];
                    retValue[0] = "L";
                    retValue[1] = "U";
                }
                else
                {
                    retValue = new string[1];
                    Queue<string> moves = new Queue<string>();
                    moves.Enqueue("L");
                    moves.Enqueue("U");
                    string move = "";
                    byte a = 0;
                    byte mc = (byte)moves.Count;
                    for (int i = 0; i < mc; i++)
                    {
                        move = moves.Dequeue();
                        if (move != Reverse[previousMove] && a < retValue.Length)
                        {
                            retValue[a] = move;
                            a = (byte)(a + 1);
                        }
                    }
                }
            }
            else if (posistionOfZero.X == Board.Height - 1 && posistionOfZero.Y == 0)
            {
                if (previousMove == null)
                {
                    retValue = new string[2];
                    retValue[0] = "R";
                    retValue[1] = "U";
                }
                else
                {
                    retValue = new string[1];
                    Queue<string> moves = new Queue<string>();
                    moves.Enqueue("R");
                    moves.Enqueue("U");
                    string move = "";
                    byte a = 0;
                    byte mc = (byte)moves.Count;
                    for (int i = 0; i < mc; i++)
                    {
                        move = moves.Dequeue();
                        if (move != Reverse[previousMove] && a < retValue.Length)
                        {
                            retValue[a] = move;
                            a = (byte)(a + 1);
                        }
                    }
                }
            }
            else if (posistionOfZero.X == 0 && posistionOfZero.Y > 0 && posistionOfZero.Y < Board.Width - 1)
            {
                if (previousMove == null)
                {
                    retValue = new string[3];
                    retValue[0] = "L";
                    retValue[1] = "R";
                    retValue[2] = "D";
                }
                else
                {
                    retValue = new string[2];
                    Queue<string> moves = new Queue<string>();
                    moves.Enqueue("L");
                    moves.Enqueue("R");
                    moves.Enqueue("D");
                    string move = "";
                    byte a = 0;
                    byte mc = (byte)moves.Count;
                    for (int i = 0; i < mc; i++)
                    {
                        move = moves.Dequeue();
                        if (move != Reverse[previousMove] && a < retValue.Length)
                        {
                            retValue[a] = move;
                            a = (byte)(a + 1);
                        }
                    }
                }
            }
            else if (posistionOfZero.X == Board.Height - 1 && posistionOfZero.Y > 0 && posistionOfZero.Y < Board.Width - 1)
            {
                if (previousMove == null)
                {
                    retValue = new string[3];
                    retValue[0] = "L";
                    retValue[1] = "R";
                    retValue[2] = "U";
                }
                else
                {
                    retValue = new string[2];
                    Queue<string> moves = new Queue<string>();
                    moves.Enqueue("L");
                    moves.Enqueue("R");
                    moves.Enqueue("U");
                    string move = "";
                    byte a = 0;
                    byte mc = (byte)moves.Count;
                    for (int i = 0; i < mc; i++)
                    {
                        move = moves.Dequeue();
                        if (move != Reverse[previousMove] && a < retValue.Length)
                        {
                            retValue[a] = move;
                            a = (byte)(a + 1);
                        }
                    }
                }
            }
            else if (posistionOfZero.Y == 0 && posistionOfZero.X > 0 && posistionOfZero.X < Board.Height - 1)
            {
                if (previousMove == null)
                {
                    retValue = new string[3];
                    retValue[0] = "R";
                    retValue[1] = "U";
                    retValue[2] = "D";
                }
                else
                {
                    retValue = new string[2];
                    Queue<string> moves = new Queue<string>();
                    moves.Enqueue("R");
                    moves.Enqueue("U");
                    moves.Enqueue("D");
                    string move = "";
                    byte a = 0;
                    byte mc = (byte)moves.Count;
                    for (int i = 0; i < mc; i++)
                    {
                        move = moves.Dequeue();
                        if (move != Reverse[previousMove] && a < retValue.Length)
                        {
                            retValue[a] = move;
                            a = (byte)(a + 1);
                        }
                    }
                }
            }
            else if (posistionOfZero.Y == Board.Width - 1 && posistionOfZero.X > 0 && posistionOfZero.X < Board.Height - 1)
            {
                if (previousMove == null)
                {
                    retValue = new string[3];
                    retValue[0] = "L";
                    retValue[1] = "U";
                    retValue[2] = "D";
                }
                else
                {
                    retValue = new string[2];
                    Queue<string> moves = new Queue<string>();
                    moves.Enqueue("L");
                    moves.Enqueue("U");
                    moves.Enqueue("D");
                    string move = "";
                    byte a = 0;
                    byte mc = (byte)moves.Count;
                    for (int i = 0; i < mc; i++)
                    {
                        move = moves.Dequeue();
                        if (move != Reverse[previousMove] && a < retValue.Length)
                        {
                            retValue[a] = move;
                            a = (byte)(a + 1);
                        }
                    }
                }
            }
            return retValue;
        }

        public string getRandomMove()
        {
            int HEIGHT = Board.Height;
            int WIDTH = Board.Width;
            Vector2 posistionOfZero = Board.FindZero();
            string retValue = "";

            if (posistionOfZero.X > 0 && posistionOfZero.X < HEIGHT - 1 && posistionOfZero.Y > 0 && posistionOfZero.Y < WIDTH - 1)
            {
                Random rng = new Random();
                string[] movesTemp = { "L", "R", "U", "D" };
                retValue = movesTemp[rng.Next(0, 4)];
            }
            else if (posistionOfZero.X == 0 && posistionOfZero.Y == 0)
            {
                Random rng = new Random();
                string[] movesTemp = { "R", "D" };
                retValue = movesTemp[rng.Next(0, 2)];
            }
            else if (posistionOfZero.X == 0 && posistionOfZero.Y == WIDTH - 1)
            {
                Random rng = new Random();
                string[] movesTemp = { "L", "D" };
                retValue = movesTemp[rng.Next(0, 2)];
            }
            else if (posistionOfZero.X == HEIGHT - 1 && posistionOfZero.Y == WIDTH - 1)
            {
                Random rng = new Random();
                string[] movesTemp = { "L", "U" };
                retValue = movesTemp[rng.Next(0, 2)];
            }
            else if (posistionOfZero.X == HEIGHT - 1 && posistionOfZero.Y == 0)
            {
                Random rng = new Random();
                string[] movesTemp = { "R", "U" };
                retValue = movesTemp[rng.Next(0, 2)];
            }
            else if (posistionOfZero.X == 0 && posistionOfZero.Y > 0 && posistionOfZero.Y < WIDTH - 1)
            {
                Random rng = new Random();
                string[] movesTemp = { "R", "D", "L" };
                retValue = movesTemp[rng.Next(0, 3)];
            }
            else if (posistionOfZero.X == HEIGHT - 1 && posistionOfZero.Y > 0 && posistionOfZero.Y < WIDTH - 1)
            {
                Random rng = new Random();
                string[] movesTemp = { "R", "U", "L" };
                retValue = movesTemp[rng.Next(0, 3)];
            }
            else if (posistionOfZero.Y == 0 && posistionOfZero.X > 0 && posistionOfZero.X < HEIGHT - 1)
            {
                Random rng = new Random();
                string[] movesTemp = { "D", "U", "R" };
                retValue = movesTemp[rng.Next(0, 3)];
            }
            else if (posistionOfZero.Y == WIDTH - 1 && posistionOfZero.X > 0 && posistionOfZero.X < HEIGHT - 1)
            {
                Random rng = new Random();
                string[] movesTemp = { "D", "U", "L" };
                retValue = movesTemp[rng.Next(0, 3)];
            }
            return retValue;
        }

        public void moveRandomly()
        {
            int HEIGHT = Board.Height;
            int WIDTH = Board.Width;
            Vector2 posistionOfZero = Board.FindZero();
            string move = " ";
            do
            {
                move = getRandomMove();
            } while (move == Reverse[LastMove]);

            LastMove = move;

            if (move == "U")
            {
                Vector2 pos = new Vector2(posistionOfZero.X - 1, posistionOfZero.Y);
                Board.Move(pos);
            }
            else if (move == "D")
            {
                Vector2 pos = new Vector2(posistionOfZero.X + 1, posistionOfZero.Y);
                Board.Move(pos);
            }
            else if (move == "L")
            {
                Vector2 pos = new Vector2(posistionOfZero.X, posistionOfZero.Y - 1);
                Board.Move(pos);
            }
            else if (move == "R")
            {
                Vector2 pos = new Vector2(posistionOfZero.X, posistionOfZero.Y + 1);
                Board.Move(pos);
            }
        }

        public void move(string newMove)
        {
            Vector2 posistionOfZero = Board.FindZero();

            if (newMove == "U")
            {
                Vector2 pos = new Vector2(posistionOfZero.X - 1, posistionOfZero.Y);
                Board.Move(pos);
            }
            else if (newMove == "D")
            {
                Vector2 pos = new Vector2(posistionOfZero.X + 1, posistionOfZero.Y);
                Board.Move(pos);
            }
            else if (newMove == "L")
            {
                Vector2 pos = new Vector2(posistionOfZero.X, posistionOfZero.Y - 1);
                Board.Move(pos);
            }
            else if (newMove == "R")
            {
                Vector2 pos = new Vector2(posistionOfZero.X, posistionOfZero.Y + 1);
                Board.Move(pos);
            }
        }
    }
}
