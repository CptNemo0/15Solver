using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _15puzzle.Boards;

namespace _15puzzle.States
{
    public class ASState : IState
    {
        private IState previous;
        private Board board;
        private bool isWinning;
        private string previousMove;

        private int value;

        public override IState Previous { get => previous; set => previous = value; }
        public override Board Board15 { get => board; set => board = value; }
        public override bool IsWinning { get => isWinning; set => isWinning = value; }
        public override string PreviousMove { get => previousMove; set => previousMove = value; }
        public override int Value { get => value; set => this.value = value; }

        public ASState(Board board, IState previous, string previousMove)
        {
            this.Previous = previous;
            this.PreviousMove = previousMove;
            this.Board15 = board;

            this.isWinning = false;
            this.value = 1000;
        }

        public void evaluateStateMan()
        {
            int retValue = 0;
            for (int i = 0; i < Board15.Height; i++)
            {
                for (int j = 0; j < Board15.Width; j++)
                {
                    value = Board15.Fields[i][j].Value;
                    if (value != 0)
                    {
                        value = value - 1;
                        int x = value / Board15.Height;
                        int y = value % Board15.Width;

                        x = Math.Abs(x - i);
                        y = Math.Abs(y - j);

                        retValue = retValue + y + x;
                    }
                }
            }
            Value = retValue;
        }

        public void evaluateStateHam()
        {
            int retValue = 0;
            for (int i = 0; i < Board15.Height; i++)
            {
                for (int j = 0; j < Board15.Width; j++)
                {
                    value = Board15.Fields[i][j].Value;
                    if (value != 0)
                    {
                        value = value - 1;
                        int x = value / Board15.Height;
                        int y = value % Board15.Width;

                        if (x != i || y != j)
                        {
                            retValue++;
                        }
                    }
                }
            }
            Value = retValue;
        }


        //DO NOT USE FOR THIS STATE!!!
        public override byte Depth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
