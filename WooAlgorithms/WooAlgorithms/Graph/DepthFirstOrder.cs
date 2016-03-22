using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooAlgorithms.Graph
{
    /// <summary>
    /// find the order in which things go given that they are not cyclical
    /// use this to detect cycles when not desired
    /// a class the inherits from a class that inherits from iteself
    /// a class that has a prerequisete of another class that has a prerequisite of itself
    /// and excel spread sheet formula referring to itself
    /// </summary>
    public class DepthFirstOrder
    {
        bool[] marked;
        public int[] edgeTo;
        Stack<int> reverseOrder = new Stack<int>();
        public DepthFirstOrder(Graph g)
        {
            marked = new bool[g.V];
            for (int i = 0; i < g.V; i++)
            {
                if (!marked[i])
                {
                    dfs(g, i);
                }
            }
        }
        void dfs(Graph g, int v)
        {
            marked[v] = true;
            foreach (var w in g.Adj(v))
            {
                if (!marked[w])
                {
                    dfs(g, w);
                }
            }
            reverseOrder.Push(v);
        }

        public IEnumerable<int> ReverseOrder()
        {
            while (reverseOrder.Count > 0)
            {
                yield return reverseOrder.Pop();
            }
        }
    }
}
