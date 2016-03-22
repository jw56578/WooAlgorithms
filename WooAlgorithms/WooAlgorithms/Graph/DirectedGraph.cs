using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooAlgorithms.Graph
{
    /// <summary>
    /// an example is the tree structuror of code
    /// is there an infinite loop
    /// is there unreachable code
    /// garbage collection - mark and sweep
    /// 
    /// </summary>
    public class DirectedGraph:Graph
    {
        public DirectedGraph(int v):base(v)
        {
            this.V = v;
            adj = new List<int>[v];
            vertex = new Vertex[v];
            v--;
            while (v >= 0)
            {
                //should there be another array to hold the actual object?
                var vert = new Vertex() { Id = v };
                vertex[v] = vert;
                adj[v] = new List<int>();
                v--;
            }

        }
        public IEnumerable<int> Adj(int v)
        {
            foreach (var vert in adj[v])
            {
                yield return vert;
            }
        }

        public override void AddEdge(int v, int w)
        {
            adj[v].Add(w);
        }
    }
}
