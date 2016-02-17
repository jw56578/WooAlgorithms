using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooAlgorithms
{
    /// <summary>
    /// maintain an array of integers in which the index represents the numbers to be connected
    /// the value of the array indicates whether the numbers are connected
    /// this is a quadratic algorithm 
    /// </summary>
    public class QuickFind
    {
        public int[] id;

        public QuickFind(int n)
        {
            id = new int[n];
            for (int i = 0; i < n; i++)
            {
                id[i] = i;
            }
        }
        public bool Connected(int p, int q)
        {
            return id[p] == id[q];
        }
        public void Union(int p, int q)
        {
            int pid = id[p];
            int qid = id[q];
            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] == pid) id[i] = qid;
            }
        }

    }
}
