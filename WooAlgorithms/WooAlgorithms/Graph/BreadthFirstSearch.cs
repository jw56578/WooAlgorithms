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
        int[] sources;
        /// <summary>
        /// Multiple source shortest path
        /// given multiple starting points, what has the shortest path to the end point
        /// </summary>
        /// <param name="g"></param>
        /// <param name="s"></param>
        /// <param name="sources"></param>
        public BreadthFirstSearch(Graph g, int s,params int[] sources )
        {
            this.sources = sources;
        }
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
            if (sources != null)
                foreach (var ss in sources)
                {
                    q.Enqueue(ss);
                }
            q.Enqueue(s);
            marked[s] = true;
            disTo[s] = 0;
            while (q.Count != 0)
            {
                int v = q.Dequeue();
                foreach (var w in g.Adj(v))
                {
                    if (!marked[w])
                    {
                        //how do you know that you are at the next level of distance
                        //you have to somehow maintain the parent of of the node you are visiting and add one to its distance
                        //this is already recorded in edge to you just take the parent that got you to this node and get its distance and then add 1
                        disTo[w] = disTo[v] + 1;
                        q.Enqueue(w);
                        marked[w] = true;
                        edgeTo[w] = v;
                        
                    }
                }
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
