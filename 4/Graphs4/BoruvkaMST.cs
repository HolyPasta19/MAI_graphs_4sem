using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Graphs4
{
    public static class Boruvka
    {
 
        private static int Find(List<int> parent, int i)
        {
            if (parent[i] == i)
            {
                return i;
            }
            return Find(parent, parent[i]);
        }

        
        private static void UnionSet(List<int> parent, List<int> rank,
                              int x, int y)
        {
            int xroot = Find(parent, x);
            int yroot = Find(parent, y);

          
            if (rank[xroot] < rank[yroot])
            {
                parent[xroot] = yroot;
            }
            else if (rank[xroot] > rank[yroot])
            {
                parent[yroot] = xroot;
            }

            
            else
            {
                parent[yroot] = xroot;
                rank[xroot]++;
            }
        }


       
        public static List<(int, int, int)> BoruvkaMST(this Graph_int graph)
        {
            var edges = graph.List_Of_Edges();
            List<int> parent = new List<int>();

            
            List<int> rank = new List<int>();
            List<List<int>> cheapest = new List<List<int>>();
            var result = new List<(int, int, int)>();
            
            int numTrees = graph.VertexCount();


           
            for (int node = 0; node < graph.VertexCount(); node++)
            {
                parent.Add(node);
                rank.Add(0);
                cheapest.Add(new List<int> { -1, -1, -1 });
            }

           
            while (numTrees > 1)
            {

                
                for (int i = 0; i < edges.Count;i++)
                    
                {

                   
                    int u = edges[i].Item1, v = edges[i].Item2,
                        w = edges[i].Item3;
                    int set1 = Find(parent, u),
                        set2 = Find(parent, v);

                   
                    if (set1 != set2)
                    {
                        if (cheapest[set1][2] == -1
                            || cheapest[set1][2] > w)
                        {
                            cheapest[set1]
                                = new List<int> { u, v, w };
                        }
                        if (cheapest[set2][2] == -1
                            || cheapest[set2][2] > w)
                        {
                            cheapest[set2]
                                = new List<int> { u, v, w };
                        }
                    }
                }

               
                for (int node = 0; node < graph.VertexCount(); node++)
                {

                    
                    if (cheapest[node][2] != -1)
                    {
                        int u = cheapest[node][0],
                            v = cheapest[node][1],
                            w = cheapest[node][2];
                        int set1 = Find(parent, u),
                            set2 = Find(parent, v);
                        if (set1 != set2)
                        {
                          
                            UnionSet(parent, rank, set1, set2);
                            result.Add((u + 1, v + 1, w));
                            numTrees--;
                        }
                    }
                }
                for (int node = 0; node < graph.VertexCount(); node++)
                {
                    cheapest[node][2] = -1;
                }
            }
            return result;
            
        }
    }
}