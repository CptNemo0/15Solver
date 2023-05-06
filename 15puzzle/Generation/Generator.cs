using _15puzzle.Boards;
using _15puzzle.Utility;
using Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generation
{
    public class Generator
    {
        public Generator() { }

        public void generate(string filename, List<FileManager> inputFMs)
        {
            List<Board> boards2 = new List<Board>();
            List<Board> outputBoards2 = new List<Board>();
            FileManager outputfm = new FileManager(filename);
            List<Board> hs2 = new List<Board>();

            for (int i = 0; i < inputFMs.Count; i++)
            {
                boards2.AddRange(inputFMs[i].readFile());
            }

            for (int i = 0; i < boards2.Count; i++)
            {
                hs2.Add(boards2[i]);
            }

            boards2.Clear();
            boards2.AddRange(inputFMs[inputFMs.Count - 1].readFile());

            for (int i = 0; i < boards2.Count; i++)
            {
                Mover mover = new Mover(boards2[i]);
                string[] moves = mover.getPossibleMoves(null);

                for (int j = 0; j < moves.Length; j++)
                {
                    Board temp = new Board(boards2[i]);
                    Mover mover1 = new Mover(temp);
                    mover1.move(moves[j]);

                    int a = 0;
                    for (int k = 0; k < hs2.Count; k++)
                    {
                        if (temp.Equals(hs2[k]))
                        {
                            a++;
                        }
                    }

                    if (a == 0)
                    {
                        hs2.Add(temp);
                        outputBoards2.Add(temp);
                    }
                }
            }
            outputfm.writeFile(outputBoards2);
        }
    }
}
