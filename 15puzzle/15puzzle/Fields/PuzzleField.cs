using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15puzzle.Fields
{
    public class PuzzleField : IPuzzleField
    {
        private byte value;

        public PuzzleField()
        {
            value = 0;
        }

        public PuzzleField(byte value)
        {
            this.value = value;
        }

        public override byte Value { get => value; set => this.value = value; }
    }
}
