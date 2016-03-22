using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooAlgorithms.Graph
{

    public class UndirectedGraph : Graph
    {
        public UndirectedGraph(int v):base(v)
        {

        }
        public override void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v);
        }

        public override Graph Reverse()
        {
            throw new NotImplementedException();
        }
    }
}
