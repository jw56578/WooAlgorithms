using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooAlgorithms.Graph
{
    public class BreadthFirstSearch
    {
        bool[] marked;
        public int[] edgeTo;
        //no idea how to implement this
        public int[] disTo;
        int s;

        public BreadthFirstSearch(Graph g, int s)
        {
            this.s = s;
            marked = new bool[g.V];
            edgeTo = new int[g.V];
            disTo = new int[g.V];
            bfs(g, s);
        }
        void bfs(Graph g, int s)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(s);
            marked[s] = true;
            int distanceTo = 1;
            while (q.Count != 0)
            {
                int v = q.Dequeue();
                foreach (var w in g.Adj(v))
                {
                    if (!marked[w])
                    {
                        q.Enqueue(w);
                        marked[w] = true;
                        edgeTo[w] = v;
                        disTo[w] = distanceTo;
                    }
                }
                distanceTo++;
            }
        }

        public bool HasPathTo(int v)
        {
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
