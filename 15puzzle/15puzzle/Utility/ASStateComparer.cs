using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _15puzzle.States;

namespace _15puzzle.Utility
{
    public class ASStateComparer : IComparer<ASState>
    {
        public int Compare(ASState? x, ASState? y)
        {
            int retValue = 2;
            if (x != null && y != null)
            {
                if (x.Value == y.Value)
                {
                    retValue = 0;
                }
                else if (x.Value > y.Value)
                {
                    retValue = 1;
                }
                else
                {
                    retValue = -1;
                }
            }
            return retValue;
        }
    }
}
