using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooAlgorithms.Graph
{
    /// <summary>
    /// KosarajuSharirSCC
    /// </summary>
    public class StrongComponents
    {
        bool[] marked;
        public int[] id;
        int count;
        public StrongComponents(Graph g)
        {
            marked = new bool[g.V];
            id = new int[g.V];
            DepthFirstOrder dfo = new DepthFirstOrder(g.Reverse());
            foreach (int v in dfo.ReverseOrder())
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
        public bool StronglyConnected(int v, int w)
        {
            return id[v] == id[w];
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
