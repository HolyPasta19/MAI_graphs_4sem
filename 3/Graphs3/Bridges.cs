﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace Graphs3
{
    using Vertex = System.Int32;
    internal static class Bridges
    {
        static public int time = 0;
        static public List<List<(int, int)>> bridge = new List<List<(int, int)>>();

        public static void Dfs(Graph_int graph, int v, int[] enter, int[] low, bool[] visited, int[] parent)
        {
            
     
            enter[v] = time++;
            low[v] = time++;
            visited[v] = true;

            foreach (var item in graph.AdjacencyList(v))
            {
                if (!visited[item])
                {
                    parent[item] = v;
                    Dfs(graph, item, enter, low, visited,parent);
                    low[v] = Math.Min(low[v], low[item]);
                    if (low[item] > enter[v])
                    {
                        bridge.Add(new List<(int, int)>());
                        for (int i = 0; i< bridge.Count;i++)
                        {
                            if (bridge[i].Count == 0)
                            {
                                bridge[i].Add((v, item));
                            }
                        }
                        
                        
                    }

                }
                else if (item != parent[v])
                {
                    low[v] = Math.Min(low[v], enter[item]);

                }


            }


        }
        public static List<List<(int,int)>> find_bridges(this Graph_int graph)
        {

            var reversed = KosarajuSCC.ReverseGraph(graph);
            bool[] visited = new bool[graph.VertexCount()];
            int[] enter = new int[graph.VertexCount()];
            int[] parent = new int[graph.VertexCount()];
            var low = new int[graph.VertexCount()];
            
            for (int i = 0; i < graph.VertexCount(); i++)
            {
                parent[i] = -1;
                visited[i] = false;
            }
            for (int i = 0; i < graph.VertexCount(); i++)
            {
                if (visited[i]==false)
                {
                    
                    Dfs(reversed, i, enter, low, visited,parent);
                

                }
            }
            return bridge;
        }
    }
}
