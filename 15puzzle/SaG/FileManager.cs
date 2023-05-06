using _15puzzle;
using _15puzzle.Boards;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class FileManager
    {
        string fileName;

        public FileManager(string fileName)
        {
            this.FileName = fileName;
        }

        public string FileName { get => fileName; set => fileName = value; }
    
        public List<Board> readFile()
        {
            /*
            StringBuilder sb = new StringBuilder();
            sb.Append("JsonFiles\\");
            sb.Append(FileName);
            sb.Append(".json");
            */
            string json = File.ReadAllText(FileName);

            List<Connector> connectors = JsonConvert.DeserializeObject<List<Connector>>(json);
            List<Board> boards = new List<Board>();

            for (int i = 0; i < connectors.Count; i++)
            {
                Board board1 = new Board((byte)connectors[i].Height, (byte)connectors[i].Width);
                board1.Fields = connectors[i].deserialize();
                boards.Add(board1);
            }
            return boards;
        }

        public void writeFile(List<Board> boards)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Files\\");
            sb.Append(FileName);
            sb.Append(".json");

            List<Connector> connectors = new List<Connector>();

            for(int i = 0  ; i < boards.Count ; i++)
            {
                Connector connector = new Connector(boards[i].Height, boards[i].Width, boards[i].Serialize());
                connectors.Add(connector);
            }

            string json = JsonConvert.SerializeObject(connectors);

            File.WriteAllText(sb.ToString(), json);
        }
    }
}
