using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _15puzzle.Boards;
using _15puzzle.Utility;

namespace _15puzzle
{
    public class Shuffler
    {
        private IBoard board;
        private Mover mover;
        public IBoard Board { get => board; set => board = value; }
        public Mover Mover { get => mover; set => mover = value; }

        public Shuffler(IBoard board, Mover mover)
        {
            this.Board = board;
            this.Mover = mover;
        }
        public void shuffle(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                Mover.moveRandomly();
            }
        }
    }
}
