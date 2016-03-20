using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooAlgorithms.Graph
{
    /// <summary>
    /// this thing only works for one starting vertex at a time
    /// everything is based on that vertex related to other vertex
    /// </summary>
    public class DepthFirstSearch
    {
        bool[] marked;
        public int[] edgeTo;
        int s;

        public DepthFirstSearch(Graph g, int s)
        {
            this.s = s;
            marked = new bool[g.V];
            edgeTo = new int[g.V];
            dfs(g, s);
        }
        void dfs(Graph g, int v)
        {
            marked[v] = true;
            foreach (var w in g.Adj(v))
            {
                if (!marked[w])
                {
                    dfs(g, w);
                    edgeTo[w] = v;
                }
            }
        }

        public bool HasPathTo(int v) {
            return marked[v];
        }

        public IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v)) return null;
            Stack<int> path = new Stack<int>();
            for (int x = v; x != s; x = edgeTo[x])
            {
                path.Push(x);
            }

            return GetPaths(path);

        }
        private IEnumerable<int> GetPaths(Stack<int> path)
        {
            while (path.Count > 0)
            {
                yield return path.Pop();
            }
        }
    }
}
