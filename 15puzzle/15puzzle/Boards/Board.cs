using _15puzzle.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _15puzzle.Boards
{
    public class Board : IBoard
    {
        private byte width;
        private byte height;
        private IPuzzleField[][] board15;

        public override byte Width { get => width; set => width = value; }
        public override byte Height { get => height; set => height = value; }
        public override IPuzzleField[][] Fields { get => board15; set => board15 = value; }

        public Board(byte height, byte width)
        {
            Width = width;
            Height = height;
            Fields = new PuzzleField[height][];
            for (int i = 0; i < height; i++)
            {
                Fields[i] = new PuzzleField[width];
                for (int j = 0; j < width; j++)
                {
                    Fields[i][j] = new PuzzleField((byte)(width * i + j + 1));
                }
            }
            Fields[height - 1][width - 1].Value = (byte)0;
        }

        public Board(IBoard tbc)
        {
            Width = tbc.Width;
            Height = tbc.Height;
            Fields = new PuzzleField[Height][];

            for (int i = 0; i < Height; i++)
            {
                Fields[i] = new PuzzleField[Width];
            }
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Fields[i][j] = new PuzzleField(tbc.Fields[i][j].Value);
                }
            }
        }


        public override bool Equals(Board x)
        {
            bool retValue = false;
            int a = 0;
            if (Width == x.Width && Height == x.Height)
            {
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        if (Fields[i][j].Value == x.Fields[i][j].Value)
                        {
                            a++;
                        }
                    }
                }

                if (a == Width * Height)
                {
                    retValue = true;
                }
            }
            return retValue;
        }
        public override Vector2 FindZero()
        {
            Vector2 retValue = new Vector2(Height + 1, Width + 1);

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (Fields[i][j].Value == 0)
                    {
                        retValue = new Vector2(i, j);
                        break;
                    }
                }
            }

            return retValue;
        }
        public override byte[] Map()
        {
            byte[] retValue = new byte[Width * Height];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    retValue[Height * i + j] = Fields[i][j].Value;
                }
            }

            return retValue;
        }
        public override void Move(Vector2 currentPosition)
        {
            Vector2 zeroPosition = FindZero();
            IPuzzleField temp = Fields[(int)zeroPosition.X][(int)zeroPosition.Y];
            Fields[(int)zeroPosition.X][(int)zeroPosition.Y] = Fields[(int)currentPosition.X][(int)currentPosition.Y];
            Fields[(int)currentPosition.X][(int)currentPosition.Y] = temp;
        }
        public override void Print()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write("{0,-4}", Fields[i][j].Value);
                }
                Console.Write("\n");
            }
        }
        public override string Serialize()
        {
            StringBuilder sb = new StringBuilder();
            byte[] mapping = Map();
            for (int i = 0; i < mapping.Length; i++)
            {
                sb.Append(mapping[i]);
                if (i < mapping.Length - 1)
                {
                    sb.Append(",");
                }
            }
            return sb.ToString();
        }
    }
}
