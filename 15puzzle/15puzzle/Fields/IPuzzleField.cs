using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15puzzle.Fields
{
    public abstract class IPuzzleField
    {
        public abstract byte Value { get; set; }

        public static IPuzzleField CreateEmptyPuzzleField()
        {
            return new PuzzleField();
        }

        public static IPuzzleField CreatePuzzleField(byte value)
        {
            return new PuzzleField(value);
        }
    }
}
