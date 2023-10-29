using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Graphs8
{
    public class Map
    {
        private List<List<Cell>> map = new List<List<Cell>>();
        public Map(string path)
        {
            string[] lines = File.ReadAllLines(path);
            int[,] rawMap;
            rawMap = new int[lines.Length, lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                    if (temp[j] != "")
                        rawMap[i, j] = Int32.Parse(temp[j]);
            }
            for (int i = 0; i < rawMap.GetUpperBound(0) + 1; i++)
            {
                List<Cell> vec = new List<Cell>();
                for (int j = 0; j < rawMap.GetUpperBound(0)+1; j++)
                {
                    Cell cell = new Cell();
                    cell.height = rawMap[i,j];
                    cell.x = i;
                    cell.y = j;
                    vec.Add(cell);
                }
                map.Add(vec);
            }
        }
        public Cell Get( int x, int y)
        {
            return map[x][y];
        }
        public List<Cell> neighbors(Cell cell)
        {
            List<Cell> res = new List<Cell>();
            if (cell.x>0)
            {
                res.Add(map[cell.x - 1][cell.y]);
            }
            if (cell.x < map.Count()-1)
            {
                res.Add(map[cell.x + 1][cell.y]);
            }
            if (cell.y > 0)
            {
                res.Add(map[cell.x][cell.y - 1]);
            }
            if (cell.y < map.Count()-1)
            {
                res.Add(map[cell.x][cell.y + 1]);
            }
            return res;
        }
        public int size()
        {
            return map.Count;
        }


    }
}
