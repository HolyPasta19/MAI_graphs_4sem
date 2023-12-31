﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs5
{
    using Vertex = System.Int32;
    public interface Graph_int
    {
        public int Weight(Vertex vi, Vertex vj);
        public bool IsEdge(Vertex vi, Vertex vj);
        public int[,] AdjacencyMatrix();
        public List<int> AdjacencyList(Vertex v);
        public List<(int, int, int)> ListOfEdges();
        public List<(int, int, int)> ListOfEdges(Vertex v);
        public bool IsDirected();
        public int VertexCount();
    }
}
