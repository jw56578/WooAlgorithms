using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooAlgorithms.Graph
{
    public class ConnectedComponents
    {
        bool[] marked;
        public int[] id;
        int count;
        public ConnectedComponents(Graph g)
        {
            marked = new bool[g.V];
            id = new int[g.V];
            for (int v = 0; v < g.V; v++)
            {
                if (!marked[v])
                {
                    dfs(g, v);
                    count++;
                }
            }
        }

        public int Count()
        {
            return count;
        }
        public int Id(int v)
        {
            return id[v];
        }
        void dfs(Graph g, int v)
        {
            marked[v] = true;
            id[v] = count;
            foreach (var w in g.Adj(v))
            {
                if (!marked[w])
                {
                    dfs(g, w);
                }
            }
        }
    }
}
