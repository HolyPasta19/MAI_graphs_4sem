using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs2
{
    using Vertex = System.Int32;
    public interface Graphs_int
    {
        public int Weight(Vertex vi, Vertex vj);
        public bool IsEdge(Vertex vi, Vertex vj);
        public int[,] AdjacencyMatrix();
        public List<int> AdjacencyList(Vertex v);
        public List<(int, int, int)> List_Of_Edges();
        public List<(int, int, int)> List_Of_Edges(Vertex v);
        public bool IsDirected();
        public int VertexCount();
    }
}
