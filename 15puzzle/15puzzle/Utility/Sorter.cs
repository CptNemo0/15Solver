using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15puzzle.Utility
{
    public class Sorter
    {
        private string[] order;
        public string[] Order { get => order; set => order = value; }

        public Sorter(int order)
        {
            this.Order = new string[4];

            // RDUL
            if (order == 0)
            {
                this.Order[0] = "R";
                this.Order[1] = "D";
                this.Order[2] = "U";
                this.Order[3] = "L";
            }
            // RDLU
            else if (order == 1)
            {
                this.Order[0] = "R";
                this.Order[1] = "D";
                this.Order[2] = "L";
                this.Order[3] = "U";
            }
            // DRUL
            else if (order == 2)
            {
                this.Order[0] = "D";
                this.Order[1] = "R";
                this.Order[2] = "U";
                this.Order[3] = "L";
            }
            // DRLU
            else if (order == 3)
            {
                this.Order[0] = "D";
                this.Order[1] = "R";
                this.Order[2] = "L";
                this.Order[3] = "U";
            }
            // LUDR
            else if (order == 4)
            {
                this.Order[0] = "L";
                this.Order[1] = "U";
                this.Order[2] = "D";
                this.Order[3] = "R";
            }
            // LURD
            else if (order == 5)
            {
                this.Order[0] = "L";
                this.Order[1] = "U";
                this.Order[2] = "R";
                this.Order[3] = "D";
            }
            // ULDR
            else if (order == 6)
            {
                this.Order[0] = "U";
                this.Order[1] = "L";
                this.Order[2] = "D";
                this.Order[3] = "R";
            }
            // ULRD
            else if (order == 7)
            {
                this.Order[0] = "U";
                this.Order[1] = "L";
                this.Order[2] = "R";
                this.Order[3] = "D";
            }
        }
        public void sort(ref string[] moves)
        {
            Array.Sort(moves, (a, b) => Array.IndexOf(Order, a).CompareTo(Array.IndexOf(Order, b)));
        }
    }
}
