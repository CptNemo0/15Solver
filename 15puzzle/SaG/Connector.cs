using _15puzzle.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class Connector
    {
        private int width;
        private int height;
        private string serializedBoard;

        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public string SerializedBoard { get => serializedBoard; set => serializedBoard = value; }

        public Connector() { }

        public Connector(int height, int width)
        {
            this.width = width;
            this.height = height;
        }

        public Connector(int height, int width, string serializedBoard)
        {
            this.Width = width;
            this.Height = height;
            this.serializedBoard = serializedBoard;
        }
    
        public PuzzleField[][] deserialize()
        {
            PuzzleField[][] retValue = new PuzzleField[height][];
            for(int i = 0; i < height; i++)
            {
                retValue[i] = new PuzzleField[width];
            }

            byte[] mapping = serializedBoard.Split(',').Select(byte.Parse).ToArray();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    retValue[i][j] = new PuzzleField(mapping[(Height * i) + j]);
                }
            }

            return retValue;
        }
    }
}
