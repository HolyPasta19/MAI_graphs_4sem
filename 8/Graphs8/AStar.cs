using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Graphs8
{
    
    public static class AstarRealiz
    {
        public static Tuple<List<Cell>, int, int> AStar(this Map map, Cell start, Cell end, Func<Cell, Cell, int> heuristic)
        {
            int viewed=0;
            HashSet<Tuple<int,int>> viewVertex = new HashSet<Tuple<int,int>>();
            int count = 0;
            PriorityQueue<Cell, int> openSet = new PriorityQueue<Cell, int>();
            start.priority = heuristic(start, end);
            List<List<Cell>> cameFrom = new List<List<Cell>>();
            List<List<int>> costSoFar = new List<List<int>>();
            List<Cell> empty = new List<Cell>();
            for (int i = 0; i<map.size();i++)
            {
                List<Cell> cameLine = new List<Cell>();
                List<int> costLine = new List<int>();
                for (int j = 0; j < map.size();j++) 
                {
                    Cell cell = new Cell();
                    cell.x = -1;
                    cell.y = -1;
                    cell.height = -1;
                    cell.priority = -1;
                    cameLine.Add(cell);
                    costLine.Add(-1);
                }
                cameFrom.Add(cameLine);
                costSoFar.Add(costLine);
            }

            openSet.Enqueue(start,heuristic(start,end));
            costSoFar[start.x][start.y] = 0;

            while (openSet.Count!=0)
            {
                Cell current = openSet.Dequeue();

                if (current.PositionEqual(end))
                {
                    List<Cell> path = new List<Cell>();
                    path.Add(current);
                    Cell prev = cameFrom[current.x][current.y]; 
                    while (prev.x != -1) 
                    {
                        path.Add(prev);
                        prev = cameFrom[prev.x][prev.y]; 
                    }
                    path.Reverse();
                    return (path, count, viewed).ToTuple();
                }
                foreach (var neighbor in map.neighbors(current))
                {
                    if (!viewVertex.Contains((neighbor.x, neighbor.y).ToTuple()))
                    {
                        count++;
                    }
                    viewVertex.Add((neighbor.x, neighbor.y).ToTuple());
                    int heightDif = Math.Abs(current.height - neighbor.height);
                    int newCost = costSoFar[current.x][current.y] + 1 + heightDif;
                    if (costSoFar[neighbor.x][neighbor.y] == -1 || costSoFar[neighbor.x][neighbor.y]>newCost)
                    {
                        costSoFar[neighbor.x][neighbor.y] = newCost;
                        Cell newCell = new Cell();
                        newCell.x = neighbor.x;
                        newCell.y = neighbor.y;
                        newCell.priority = newCost + heuristic(neighbor, end);
                        newCell.height = neighbor.height;
                        openSet.Enqueue(newCell,newCell.priority);
                        cameFrom[neighbor.x][neighbor.y] = current;
                    }
                }
            }
            return (empty, -1, 0).ToTuple();
        }
        public static int PathCost(this Map map, List<Cell> path)
        {
            int cost = 0;
            for (int i = 0;i < path.Count-1; i++)
            {
                Cell current = path[i+1];
                Cell next = path[i];
                int dif = Math.Abs(map.Get(current.x, current.y).height - map.Get(next.x, next.y).height);
                cost += 1 + dif;
            }
            return cost;
        }
    }
}
