using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using _15puzzle.Fields;

namespace _15puzzle.Boards
{
    public abstract class IBoard
    {
        public abstract byte Height { get; set; }
        public abstract byte Width { get; set; }
        public abstract IPuzzleField[][] Fields { get; set; }

        public static IBoard CreateBoard(byte height, byte width)
        {
            return new Board(height, width);
        }
        public static IBoard CreateBoardCopy(IBoard tbc)
        {
            return new Board(tbc);
        }

        public abstract bool Equals(Board other);
        public abstract Vector2 FindZero();
        public abstract byte[] Map();
        public abstract void Move(Vector2 currentPosition);
        public abstract void Print();
        public abstract string Serialize();
    }
}
